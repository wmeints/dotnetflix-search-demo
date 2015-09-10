using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Weblog.Services;
using Weblog.Models;

namespace Weblog.Controllers
{
    public class SearchController : Controller
    {
        private IPostSearcher _searcher;

        public SearchController(IPostSearcher searcher)
        {
            _searcher = searcher;
        }

        [HttpGet]
        [Route("/Search")]
        public async Task<IActionResult> Search(string q, int page = 0)
        {
            ViewBag.Title = "Search results";
            ViewBag.QueryString = q;
            
            var results = await _searcher.FindPostsAsync(q, page);

            return View(results);
        }
    }
}
