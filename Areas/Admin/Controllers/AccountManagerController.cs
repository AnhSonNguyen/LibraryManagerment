using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public AccountManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // Danh sách tài khoản
        public async Task<IActionResult> Index()
        {
            var accounts = await _context.TbAccounts.ToListAsync();
            return View(accounts);
        }

        // GET: Thêm tài khoản
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thêm tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbAccount account)
        {
            if (ModelState.IsValid)
            {
                account.IsActive = true;
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Sửa tài khoản
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _context.TbAccounts.FindAsync(id);
            if (account == null)
                return NotFound();
            return View(account);
        }

        // POST: Sửa tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbAccount account)
        {
            if (ModelState.IsValid)
            {
                _context.Update(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Xóa tài khoản
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _context.TbAccounts.FindAsync(id);
            if (account == null)
                return NotFound();
            return View(account);
        }

        // POST: Xóa xác nhận
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.TbAccounts.FindAsync(id);
            if (account != null)
            {
                _context.TbAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
