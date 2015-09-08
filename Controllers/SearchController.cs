using System;
using Microsoft.AspNet.Mvc;

namespace Weblog.Controllers
{
    public class SearchController: Controller
    {
        [HttpGet]
        [Route("/Search")]
        public IActionResult Search(string q)
        {
            ViewBag.Title = "Search results";
            return View();
        }
    }
}
