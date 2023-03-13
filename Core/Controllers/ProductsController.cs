using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ApplicationContext _db;

        public ProductsController(ApplicationContext db)
        {
            _db = db;
        }

        // api/products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products;
        }

        // api/products/1
        [HttpGet("{id}")]
        public Product GetProduct([FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("-------------------- GetProduct Action Invoked ------------------");
            return _db.Products.FirstOrDefault();
        }
    }
}
