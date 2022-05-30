using AutoMapper;
using Buoi17_First.Data;
using Buoi17_First.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductController (ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index(int? id)
        {
            var products = _context.Products.AsQueryable();
            if(id.HasValue)
            {
                products = products.Where(p=> p.CategoryId == id);
            }
            var data = _mapper.Map<List<ProductViewModel>>(products.ToList());
            return View(data);
        }
    }
}
