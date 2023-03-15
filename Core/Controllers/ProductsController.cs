using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _db.Products.AsAsyncEnumerable();
        }

        // api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            Product product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // api/products
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return Ok(product);
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