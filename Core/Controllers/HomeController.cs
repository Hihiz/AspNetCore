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
            return View(await _db.Products.FindAsync(id));
        }

        public IActionResult Common(long id)
        {
            return View("/Views/Shared/Common.cshtml");
        }
    }
}
