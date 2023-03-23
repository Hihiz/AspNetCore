using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class FormController : Controller
    {
        private ApplicationContext _db;

        public FormController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            return View(await _db.Products.FindAsync(id));
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (string key in Request.Form.Keys)
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }

            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
