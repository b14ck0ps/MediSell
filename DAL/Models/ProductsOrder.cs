using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductsOrder
    {
        [Key] public int Id { get; set; }

        [Required] public int Quantity { get; set; }

        // Foreign Key
        [ForeignKey("Product")] public int ProductId { get; set; }

        [ForeignKey("Order")] public int OrderId { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}