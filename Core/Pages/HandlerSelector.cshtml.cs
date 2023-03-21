using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Core.Pages
{
    public class HandlerSelectorModel : PageModel
    {
        private ApplicationContext _db;
        public Product Product { get; set; }

        public HandlerSelectorModel(ApplicationContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync(long id = 1)
        {
            Product = await _db.Products.FindAsync(id);
        }

        public async Task OnGetCategoryAsync(long id = 1)
        {
            Product = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
