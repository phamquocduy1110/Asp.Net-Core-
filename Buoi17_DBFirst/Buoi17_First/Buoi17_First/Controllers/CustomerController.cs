using Buoi17_First.Data;
using Buoi17_First.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopDbContext _context;

        public CustomerController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }
    }
}
