using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    public class FormController : Controller
    {
        private ApplicationContext _db;

        public FormController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index([FromQuery] long id = 1)
        {
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
            return View(await _db.Products.Include(p => p.Category).FirstAsync(p => p.Id == id));
        }

        [HttpPost]
        //public IActionResult SubmitForm(string name, decimal price)
        public IActionResult SubmitForm([Bind("Name")] Product product)
        {
            //TempData["name param"] = name;
            //TempData["price param"] = price.ToString();

            TempData["product"] = System.Text.Json.JsonSerializer.Serialize(product);

            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            return View();
        }

        public string Header([FromHeader(Name = "Accept-Language")] string accept)
        {
            return $"Header: {accept}";
        }
    }
}
