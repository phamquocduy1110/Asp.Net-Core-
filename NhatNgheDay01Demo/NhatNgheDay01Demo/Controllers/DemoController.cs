using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
