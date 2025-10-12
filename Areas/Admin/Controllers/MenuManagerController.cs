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

        // Thêm các action Create, Edit, Delete ở đây (scaffold hoặc tự viết)
    }
}