using Buoi17_First.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductController (ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id )
        {
            var products = _context.Products.AsQueryable();
            if(id.HasValue)
            {
                products = products.Where(p=> p.CategoryId == id);
            }

            return View();
        }
    }
}
