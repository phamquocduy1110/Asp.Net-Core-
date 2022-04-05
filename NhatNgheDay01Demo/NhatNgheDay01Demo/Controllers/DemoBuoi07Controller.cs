using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class Demo07Controller : Controller
    {
        public IActionResult SendFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadSingleFile(IFormFile myfile)
        {
            if(myfile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var pathFile = Path.Combine(path, myfile.FileName);
                using (var newFile = new FileStream(pathFile, FileMode.Create))
                {
                    myfile.CopyTo(newFile);
                }
            }
            return View("SendFile");
        }

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
