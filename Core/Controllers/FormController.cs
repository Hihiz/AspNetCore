using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private ApplicationContext _db;

        public FormController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectedList
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
