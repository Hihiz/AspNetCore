using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Core.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
