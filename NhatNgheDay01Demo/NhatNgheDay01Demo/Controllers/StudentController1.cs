using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Controllers
{
    public class StudentController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
