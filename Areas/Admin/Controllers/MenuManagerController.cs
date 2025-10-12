using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuManagerController : Controller
    {
        private readonly QltvthttContext _context;
        public MenuManagerController(QltvthttContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.TbMenus.ToListAsync();
            return View(menus);
        }

        // GET: Admin/MenuManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbMenu menu)
        {
            if (ModelState.IsValid)
            {
                menu.CreatedDate = DateTime.Now;
                menu.IsActive = true;
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }
        // GET: Edit
        public IActionResult Edit(int id)
        {
            var menu = _context.TbMenus.Find(id);
            if (menu == null) return NotFound();
            return View(menu);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbMenu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Update(menu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }
        // GET: Delete
        public IActionResult Delete(int id)
        {
            var menu = _context.TbMenus.FirstOrDefault(m => m.MenuId == id);
            if (menu == null) return NotFound();
            return View(menu);
        }

        // POST: Delete (Xác nhận xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var menu = _context.TbMenus.Find(id);
            if (menu != null)
            {
                _context.TbMenus.Remove(menu);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}