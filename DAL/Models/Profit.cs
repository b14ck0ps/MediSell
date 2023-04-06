using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Profit
    {
        [Key] public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required] public decimal ProfitAmount { get; set; }

        // Foreign Key
        [ForeignKey("Product")] public int ProductId { get; set; }

        // Navigation Property
        public virtual Product Product { get; set; }
    }
}