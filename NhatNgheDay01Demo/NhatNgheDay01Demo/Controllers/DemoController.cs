using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Manage(SinhVien model)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        // /Demo/Hello
        // /Demo/Hello?ten=NhatNghe // routing default
        [HttpGet("Chao")]
        [HttpGet("/Hello")]
        [HttpGet("/Hello/{ten}")]
        public string Hello(string ten)
        {
            return $"Hello {ten}.";
        }

        // Demo friendly URL/SEO
        [HttpGet("/{loai}/{hanghoa}")]
        public string LayHangHoa(string loai, string hanghoa)
        {
            return $"Loại: {loai}/hàng hóa: {hanghoa}";
        }
    }
}
