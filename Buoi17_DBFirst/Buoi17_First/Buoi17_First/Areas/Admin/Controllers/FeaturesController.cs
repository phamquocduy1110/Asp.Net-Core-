using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buoi17_First.Data;
using Buoi17_First.ViewModels;

namespace Buoi17_First.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturesController : Controller
    {
        private readonly ShopDbContext _context;

        public FeaturesController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult AssignPermission()
        {
            var data = _context.FeatureRoles
                    .Include(fr => fr.Role)
                    .Include(fr => fr.Feature)
                    .OrderBy(fr => fr.FeatureId)
                    .ToList();

            var roles = _context.Roles.ToList();
            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");

            var dataGroup = _context.FeatureRoles
                .Include(fr => fr.Role)
                    .Include(fr => fr.Feature)
                    .ToList()
                .GroupBy(fr => new
                {
                    fr.FeatureId,
                    fr.Feature!.FeatureName
                })
                .Select(g => new FeatureRoleViewModel
                {
                    FeatureId = g.Key.FeatureId,
                    FeatureName = g.Key.FeatureName,
                    RoleNames = string.Join(", ", g.Select(frg => frg.Role.RoleName).ToList()),
                    RoleIds = string.Join(", ", g.Select(frg => frg.RoleId).ToList()),
                })
                .ToList();

            //return View(data);
            return View(dataGroup);
        }

        // GET: Admin/Features
        public async Task<IActionResult> Index()
        {
              return _context.Features != null ? 
                          View(await _context.Features.ToListAsync()) :
                          Problem("Entity set 'ShopDbContext.Features'  is null.");
        }

        // GET: Admin/Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.FeatureId == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // GET: Admin/Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatureId,FeatureName,Url")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Admin/Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        // POST: Admin/Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatureId,FeatureName,Url")] Feature feature)
        {
            if (id != feature.FeatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(feature.FeatureId))
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
            return View(feature);
        }

        // GET: Admin/Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.FeatureId == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // POST: Admin/Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Features == null)
            {
                return Problem("Entity set 'ShopDbContext.Features'  is null.");
            }
            var feature = await _context.Features.FindAsync(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureExists(int id)
        {
          return (_context.Features?.Any(e => e.FeatureId == id)).GetValueOrDefault();
        }
    }
}
