using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public RoleManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // GET: Danh sách tác giả
        public async Task<IActionResult> Index()
        {
            var Roles = await _context.TbRoles.ToListAsync();
            return View(Roles);
        }

        // GET: Thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbRole Role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Role);
        }

        // GET: Sửa
        public IActionResult Edit(int id)
        {
            var Role = _context.TbRoles.Find(id);
            if (Role == null)
                return NotFound();
            return View(Role);
        }

        // POST: Sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbRole Role)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Role);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Role);
        }

        // GET: Xóa (xác nhận)
        public IActionResult Delete(int id)
        {
            var Role = _context.TbRoles.FirstOrDefault(a => a.RoleId == id);
            if (Role == null)
                return NotFound();
            return View(Role);
        }

        // POST: Xóa (thực thi)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Role = _context.TbRoles.Find(id);
            if (Role != null)
            {
                _context.TbRoles.Remove(Role);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
