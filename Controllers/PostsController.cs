using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using Weblog.Models;
using Weblog.Repositories;
using Weblog.Services;

namespace Weblog.Controllers
{
    public class PostsController: Controller
    {
        private IPostRepository _postsRepository;
        private IPostIndexer _indexer;

        public PostsController(IPostRepository postsRepository, IPostIndexer indexer)
        {
            _postsRepository = postsRepository;
            _indexer = indexer;
        }

        [HttpGet]
        [Route("/Posts/{identifier}")]
        public async Task<IActionResult> Details(string identifier) {
            ObjectId parsedIdentifier;

            if(!ObjectId.TryParse(identifier, out parsedIdentifier))
            {
                Response.StatusCode = 400;
                return Content("Invalid identifier specified");
            }

            var post = await _postsRepository.FindByIdAsync(parsedIdentifier);

            if(post == null) {
                return HttpNotFound();
            }

            ViewBag.Title = post.Title;

            return View(post);
        }

        [HttpGet]
        [Route("/Admin/Posts/New")]
        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/Posts")]
        public async Task<IActionResult> CreateNew(string title, string body)
        {
            // Store the post in the database first.
            // After that, send the indexing request to elastic search
            var newPost = await _postsRepository.InsertAsync(new Post()
            {
                Title = title,
                Body = body,
                Author = new AuthorInfo()
                {
                    FullName = "Willem Meints",
                    EmailAddress = "some-email@domain.org"
                },
                Tags = new List<string>()
            });

            // Send indexing request to the elastic search server.
            await _indexer.IndexAsync(newPost);

            return Redirect("~/Posts/" + newPost.Id.ToString());
        }
    }
}
