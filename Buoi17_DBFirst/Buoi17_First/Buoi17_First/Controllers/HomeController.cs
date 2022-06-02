using Buoi17_First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buoi17_First.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/NotFound")]
        #pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public IActionResult NotFound()
        #pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}