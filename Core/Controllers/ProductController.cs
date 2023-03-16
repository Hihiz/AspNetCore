using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ApplicationContext _db;

        public ProductController(ApplicationContext db)
        {
            _db = db;
        }

        // api/product
        [HttpGet]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _db.Products.AsAsyncEnumerable();
        }

        // api/product/1
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

        // api/product
        [HttpPost]
        [Consumes("application/xml")]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return Ok(product);
        }

        // api/product
        [HttpPut]
        public void UpdateProduct(Product product)
        {
            _db.Update(product);
            _db.SaveChanges();
        }

        // api/product/1
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            _db.Products.Remove(new Product { Id = id });
            _db.SaveChanges();
        }

        // api/product/1
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            //return Redirect("/api/product/1");
            //return RedirectToAction(nameof(GetProduct), new { Id = 1 });
            return RedirectToRoute(new
            {
                controller = "Product",
                action = "GetProduct",
                Id = 1
            });
        }
    }
}