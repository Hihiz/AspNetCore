using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Components
{
    [ViewComponent(Name = "JuicyFruit")]
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
            return $"There are {_db.Products.Count()} products";
        }
    }
}
