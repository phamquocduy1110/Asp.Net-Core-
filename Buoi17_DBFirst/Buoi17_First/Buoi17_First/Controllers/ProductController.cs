using AutoMapper;
using Buoi17_First.Data;
using Buoi17_First.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //var data = _mapper.Map<List<ProductViewModel>>(products.ToList());


            var data = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Image = p.Image,
                Price = p.ProductPrices.FirstOrDefault().Price
            }).ToList();

            return View(data);

            //Cách 3
            //foreach(var item in data)
            //{
            //    var p_price = _context.ProductPrices.FirstOrDefault(c => c.ProductId == item.ProductId);
            //    if (p_price != null)
            //    {
            //        item.SoldPrice = p_price.Price;
            //    }
            //}
        }

        // GET: HangHoa/Details/5
        public IActionResult Details(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var hannghoa = _context.Products
                .Include(p => p.ProductPrices)
                .ThenInclude(p => p.Size)
                .SingleOrDefault(p => p.ProductId == id);
            if(hannghoa == null)
            {
                return NotFound();
            }

            ViewBag.Colors = _context.Colors.ToList(); 
            ViewBag.Sizes = _context.Sizes.ToList();
            return View(hannghoa);
        }
    }
}
