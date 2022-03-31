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
            ViewBag.HangHoa = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia Sài Gòn",
                Price = 14500,
                Quantity = 24
            };

            var hangHoa = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia Sài Gòn",
                Price = 14500,
                Quantity = 24
            };
            ViewBag.HangHoa = hangHoa;
            TempData["hanghoa"] = hangHoa;

            return View();
        }
    }
}
