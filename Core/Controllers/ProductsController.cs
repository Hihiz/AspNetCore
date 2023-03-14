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
        public Product GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("-------------------- GetProduct Action Invoked ------------------");
            return _db.Products.Find(id);
        }

        // api/products
        [HttpPost]
        public void SaveProduct([FromBody] Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        // api/products
        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            _db.Update(product);
            _db.SaveChanges();
        }

        // api/products/1
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            _db.Products.Remove(new Product { Id = id });
            _db.SaveChanges();
        }
    }
}
