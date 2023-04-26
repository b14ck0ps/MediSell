using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProfitDto
    {
        [Key] public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required] public decimal ProfitAmount { get; set; }

        // Foreign Key
        [ForeignKey("Product")] public int ProductId { get; set; }
    }
}
