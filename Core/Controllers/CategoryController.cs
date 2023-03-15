using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ApplicationContext _db;

        public CategoryController(ApplicationContext db)
        {
            _db = db;
        }

        // api/category/1
        [HttpGet("{id}")]
        public async Task<Category> GetCategory(long id)
        {
            Category category = await _db.Categories.Include(c => c.Products).FirstAsync(c => c.Id == id);

            if (category.Products != null)
            {
                foreach (Product product in category.Products)
                {
                    product.Category = null;
                }
            }

            return category;
        }
    }
}
