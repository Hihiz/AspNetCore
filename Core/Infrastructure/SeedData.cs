using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() == 0 && context.Categories.Count() == 0)
            {
                Category fruit = new Category { Name = "fruit" };
                Category shirt = new Category { Name = "shirt" };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Apple",
                        Price = 1.50M,
                        Category = fruit
                    },

                    new Product
                    {
                        Name = "Lemon",
                        Price = 2M,
                        Category = fruit
                    },

                    new Product
                    {
                        Name = "Watermelon",
                        Price = 0.50M,
                        Category = fruit
                    },
                    new Product
                    {
                        Name = "Grapefruit",
                        Price = 2.50M,
                        Category = fruit
                    },
                    new Product
                    {
                        Name = "Blue shirt",
                        Price = 5.99M,
                        Category = shirt
                    },
                    new Product
                    {
                        Name = "Black shirt",
                        Price = 7.99M,
                        Category = shirt
                    },
                    new Product
                    {
                        Name = "Red shirt",
                        Price = 9.99M,
                        Category = shirt
                    },
                    new Product
                    {
                        Name = "Yellow shirt",
                        Price = 11.99M,
                        Category = shirt
                    });

                context.SaveChanges();
            }
        }
    }
}
