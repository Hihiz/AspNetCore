using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private ApplicationContext _db;

        public FormController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
            return View(await _db.Products.Include(p => p.Category).FirstAsync(p => p.Id == id));
        }

        [HttpPost]
        //[IgnoreAntiforgeryToken]
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
