using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
