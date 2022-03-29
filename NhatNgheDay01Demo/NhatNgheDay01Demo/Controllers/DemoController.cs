using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Controllers
{
    public class DemoController : Controller
    {
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
