using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Services;

namespace NhatNgheDay01Demo.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategory _category;

        public CategoryMenu(ICategory category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_category.GetAll());
        }
    }
}
