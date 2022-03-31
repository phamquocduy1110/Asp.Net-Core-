using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class Demo07Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nhất Nghệ";
            ViewBag.NamThanhLap = new DateTime(2003, 3, 10);
            return View();
        }
    }
}
