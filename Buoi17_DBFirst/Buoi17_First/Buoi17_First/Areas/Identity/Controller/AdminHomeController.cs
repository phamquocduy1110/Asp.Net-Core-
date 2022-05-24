using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Areas
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
