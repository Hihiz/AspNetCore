using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationContext _db;
        public Product Product { get; set; }

        public EditModel(ApplicationContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync(long id = 1)
        {
            Product = await _db.Products.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(long id, decimal price)
        {
            Product product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                product.Price = price;
            }

            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
