using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Controllers
{
    public class Buoi10LayoutsController : Controller
    {
        public IActionResult NoTemplate()
        {
            return View();
        }

        public IActionResult NewLayout()
        {
            return View();
        }

        public IActionResult DanhSach()
        {
            var danhSach = new string[]
            {
                "Bia", "Nước ngot", "Cafe"
            };
            return PartialView("Category", danhSach);
        }
    }
}
