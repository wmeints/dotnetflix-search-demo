using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using Weblog.Models;
using Weblog.Repositories;

namespace Weblog.Controllers
{
    public class PostsController: Controller
    {
        private IPostRepository _postsRepository;

        public PostsController(IPostRepository postsRepository)
        {
            _postsRepository = postsRepository;
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

    }
}
