using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

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

        public string Invoke()
        {
            if (RouteData.Values["controller"] != null)
            {
                return "Controller request";
            }
            else
            {
                return "Razor Page request";
            }
        }
    }
}