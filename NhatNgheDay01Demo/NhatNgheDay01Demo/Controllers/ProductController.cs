using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia 333",
                Price = 15900,
                Quantity = 23
            },
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia Heineiken",
                Price = 19500,
                Quantity = 29
            }
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var product = Products.SingleOrDefault(item => item.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Product model)
        {
            var product = Products.SingleOrDefault(item => item.Id == id);
            if (product != null)//có
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Quantity = model.Quantity;

                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
