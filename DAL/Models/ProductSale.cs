using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductSale
    {
        [Key] public int Id { get; set; }
        [Required] public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Price")]
        public decimal Profit { get; set; }

        public DateTime Date { get; set; }

        // Foreign Key
        [ForeignKey("Product")] public int ProductId { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; }
    }
}