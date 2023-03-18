using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            return View(await _db.Products.FindAsync(id));
        }

        public IActionResult Common(long id)
        {
            return View("/Views/Shared/Common.cshtml");
        }

        public async Task<IActionResult> List()
        {
            ViewBag.AveragePrice = await _db.Products.AverageAsync(p => p.Price);

            return View(await _db.Products.ToListAsync());
        }

        public IActionResult Redirect()
        {
            TempData["value"] = "TempData value";
            return RedirectToAction("Index", new { id = 1 });
        }
    }
}
