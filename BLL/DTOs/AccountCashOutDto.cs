using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AccountCashOutDto
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
    }
}
