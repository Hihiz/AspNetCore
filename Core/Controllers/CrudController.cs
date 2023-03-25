using Microsoft.AspNetCore.Mvc;
using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Core.Models.ViewModels;
using Core.Models;

namespace Core.Controllers
{
    public class CrudController : Controller
    {
        private ApplicationContext _db;

        public CrudController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index() => View(_db.Products.Include(c => c.Category));

        public async Task<IActionResult> Details(long id)
        {
            Product product = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

            ProductViewModel model = ViewModelFactory.Details(product);

            return View("ProductEditor", model);
        }

        public IActionResult Create() => View("ProductEditor", ViewModelFactory.Create(new Product(), _db.Categories));

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("ProductEditor", ViewModelFactory.Create(product, _db.Categories));
        }
    }
}
