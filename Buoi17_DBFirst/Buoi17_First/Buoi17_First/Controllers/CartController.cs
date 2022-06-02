using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
