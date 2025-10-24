using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public CategoryManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // GET: Admin/CategoryManager
        public async Task<IActionResult> Index()
        {
            var categories = await _context.TbCategories.ToListAsync();
            return View(categories);
        }

        // GET: Admin/CategoryManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbCategory category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.IsActive = true;
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/CategoryManager/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Admin/CategoryManager/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbCategory category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    category.ModifiedDate = DateTime.Now;
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TbCategories.Any(e => e.CategoryId == category.CategoryId))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(category);
        }

        // GET: Admin/CategoryManager/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.TbCategories
                .FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Admin/CategoryManager/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category != null)
            {
                _context.TbCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
