using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public BookManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // GET: Admin/BookManager
        public async Task<IActionResult> Index()
        {
            var books = await _context.TbBooks
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .ToListAsync();

            return View(books);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Authors = _context.TbAuthors.ToList();
            ViewBag.Publishers = _context.TbPublishers.ToList();
            ViewBag.Categories = _context.TbCategories.ToList();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbBook book)
        {
            if (ModelState.IsValid)
            {
                book.CreatedDate = DateTime.Now;
                book.IsActive = true;

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Authors = _context.TbAuthors.ToList();
            ViewBag.Publishers = _context.TbPublishers.ToList();
            ViewBag.Categories = _context.TbCategories.ToList();

            return View(book);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var book = _context.TbBooks.Find(id);
            if (book == null) return NotFound();

            ViewBag.Authors = _context.TbAuthors.ToList();
            ViewBag.Publishers = _context.TbPublishers.ToList();
            ViewBag.Categories = _context.TbCategories.ToList();

            return View(book);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbBook book)
        {
            if (ModelState.IsValid)
            {
                book.ModifiedDate = DateTime.Now;
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Authors = _context.TbAuthors.ToList();
            ViewBag.Publishers = _context.TbPublishers.ToList();
            ViewBag.Categories = _context.TbCategories.ToList();

            return View(book);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var book = _context.TbBooks
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookId == id);

            if (book == null) return NotFound();

            return View(book);
        }

        // POST: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.TbBooks.Find(id);
            if (book != null)
            {
                _context.TbBooks.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
