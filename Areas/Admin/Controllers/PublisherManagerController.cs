using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryManagerment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublisherManagerController : Controller
    {
        private readonly QltvthttContext _context;

        public PublisherManagerController(QltvthttContext context)
        {
            _context = context;
        }

        // GET: Danh sách nxb
        public async Task<IActionResult> Index()
        {
            var publishers = await _context.TbPublishers.ToListAsync();
            return View(publishers);
        }
        // GET: Thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbPublisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Sửa
        public IActionResult Edit(int id)
        {
            var publisher = _context.TbPublishers.Find(id);
            if (publisher == null)
                return NotFound();
            return View(publisher);
        }

        // POST: Sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbPublisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Update(publisher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Xóa (xác nhận)
        public IActionResult Delete(int id)
        {
            var publisher = _context.TbPublishers.FirstOrDefault(a => a.PublisherId == id);
            if (publisher == null)
                return NotFound();
            return View(publisher);
        }

        // POST: Xóa (thực thi)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var publisher = _context.TbPublishers.Find(id);
            if (publisher != null)
            {
                _context.TbPublishers.Remove(publisher);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
