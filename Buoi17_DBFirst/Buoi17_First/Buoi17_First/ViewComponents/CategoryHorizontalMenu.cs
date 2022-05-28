using Buoi17_First.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.ViewComponents
{
    public class CategoryHorizontalMenu : ViewComponent
    {
        private readonly ShopDbContext _context;

        public CategoryHorizontalMenu(ShopDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Categories.ToList());
        }
    }
}
