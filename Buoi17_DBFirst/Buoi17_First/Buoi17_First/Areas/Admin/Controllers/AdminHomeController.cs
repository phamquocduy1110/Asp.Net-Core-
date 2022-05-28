using Microsoft.AspNetCore.Mvc;
using Buoi17_First.Models;
using System.Diagnostics;

namespace Buoi17_First.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
