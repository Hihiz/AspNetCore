using Microsoft.AspNetCore.Mvc;
using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

    }
}
