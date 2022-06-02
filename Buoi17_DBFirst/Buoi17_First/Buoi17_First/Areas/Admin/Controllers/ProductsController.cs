using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buoi17_First.Data;
using Buoi17_First.Utils;

namespace Buoi17_First.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Product/Price
        [HttpGet("Admin/Product/Price")]
        public IActionResult ManagePrice()
        {
            ViewBag.Sizes = new SelectList(_context.Sizes.ToList(), "Id", "Name");
            ViewBag.Colors = new SelectList(_context.Colors.ToList(), "Id", "Name");
            ViewBag.Products = new SelectList(_context.Products.Select(p => new
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
            }).ToList(), "ProductId", "ProductName"
            );

            var data = _context.ProductPrices
                .Include(p => p.Product)
                .Include(p => p.Size)
                .Include(p => p.Color)
                .ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdatePrice(ProductPrice model)
        {
            try
            {
                var productPrice = _context.ProductPrices.SingleOrDefault(p => p.ProductId == model.ProductId
                        && p.SizeId == model.SizeId && p.ColorId == model.ColorId);
                if (productPrice != null)
                {
                    productPrice.Price = model.Price;
                    productPrice.Quantity = model.Quantity;
                }
                else
                {
                    _context.Add(model);
                }
                _context.SaveChanges();
                return Json(new { Success = true });
            } catch
            {
                return Json(new { Success = false });
            }
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var shopDbContext = _context.Products.Include(p => p.Category);
            return View(await shopDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Image,Price,Description,CategoryId")] Product product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var imageUrl = MyTool.UploadFileToFolder(Image, "Product");
                    product.Image = imageUrl ?? MyTool.NoImage;
                }
                else
                {
                    product.Image = MyTool.NoImage;
                }
                product.ProductId = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,ProductName,Image,Price,Description,CategoryId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}