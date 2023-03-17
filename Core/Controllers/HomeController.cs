using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id)
        {
            return View("Fruit", await _db.Products.FindAsync(id));
        }
    }
}
