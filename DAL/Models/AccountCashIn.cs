using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class AccountCashIn
    {
        [ForeignKey("Product")] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please Enter Product Total")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Total")]
        public decimal Total { get; set; }

        [Required] public DateTime Date { get; set; }

        // Navigation Property
        public virtual Product Product { get; set; }
    }
}