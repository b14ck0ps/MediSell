using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [MaxLength(50, ErrorMessage = "Product Name must be less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Description")]
        [MaxLength(255, ErrorMessage = "Product Description must be less than 255 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please Enter Product Image Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        // Foreign key
        [ForeignKey("Category")] public int CategoryId { get; set; }
        [ForeignKey("Company")] public int CompanyId { get; set; }

        // Navigation property
        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual AccountCashIn AccountCashIn { get; set; }
        public virtual AccountCashOut AccountCashOut { get; set; }
        protected virtual ICollection<ProductsReview> ProductsReviews { get; set; } = new List<ProductsReview>();
        protected virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
        protected virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
        protected virtual ICollection<Profit> Profits { get; set; } = new List<Profit>();
    }
}