using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
   public class DeliveryManDto
    {
        [Key] public int Id { get; set; }
        public bool Status { get; set; }
        public int TotalDelivery { get; set; }

        public decimal TotalEarning { get; set; }

        // Foreign Key
        [ForeignKey("User")] public int UserId { get; set; }
    }
}
