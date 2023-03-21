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

        public IViewComponentResult Invoke()
        {
            //return Content("This is a <h3><i>string</i></h3>");
            return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
        }
    }
}
