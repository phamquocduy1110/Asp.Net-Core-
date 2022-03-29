using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Perform calculate math
        public ActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            // Check calculate selection
            switch(op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case 'x':
                    ViewBag.KetQua = a * b;
                    break;
                case ':':
                    ViewBag.KetQua = a / b;
                    break;
            }
            
            // Show the final result to Index View
            return View("Index");
        }
    }
}
