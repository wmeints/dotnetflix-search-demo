using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Weblog.Repositories;
using Weblog.Models;
using Serilog;

namespace Weblog.Controllers
{
    public class HomeController: Controller
    {
        private IPostRepository _postsRepository;

        public HomeController(IPostRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Index(int page = 0)
        {
            var posts = await _postsRepository.FindAll(page);
            ViewBag.Title = "Home";

            return View(posts);
        }

        [HttpGet]
        [Route("/About")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}
