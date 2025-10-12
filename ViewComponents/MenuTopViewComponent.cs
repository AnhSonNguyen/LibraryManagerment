using LibraryManagerment.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerment.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly QltvthttContext _context;
        public MenuTopViewComponent(QltvthttContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
