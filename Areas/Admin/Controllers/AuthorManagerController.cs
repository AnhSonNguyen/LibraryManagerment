using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public AuthorManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // GET: Danh sách tác giả
        public async Task<IActionResult> Index()
        {
            var authors = await _context.TbAuthors.ToListAsync();
            return View(authors);
        }

        // GET: Thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbAuthor author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Sửa
        public IActionResult Edit(int id)
        {
            var author = _context.TbAuthors.Find(id);
            if (author == null)
                return NotFound();
            return View(author);
        }

        // POST: Sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbAuthor author)
        {
            if (ModelState.IsValid)
            {
                _context.Update(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Xóa (xác nhận)
        public IActionResult Delete(int id)
        {
            var author = _context.TbAuthors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
                return NotFound();
            return View(author);
        }

        // POST: Xóa (thực thi)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.TbAuthors.Find(id);
            if (author != null)
            {
                _context.TbAuthors.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
