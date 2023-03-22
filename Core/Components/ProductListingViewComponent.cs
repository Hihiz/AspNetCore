using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Components
{
    public class ProductListingViewComponent : ViewComponent
    {
        private ApplicationContext _db;

        public IEnumerable<Product> Products;

        public ProductListingViewComponent(ApplicationContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke(string className = "primary")
        {
            ViewBag.Class = className;
            return View(_db.Products.Include(p => p.Category).ToList());
        }
    }
}