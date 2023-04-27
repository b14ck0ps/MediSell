using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DeliveryStatusDto
    {
        [Key] public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Status { get; set; }
        public int Report { get; set; }

        // Foreign Key
        [ForeignKey("Order")] public int OrderId { get; set; }

        [ForeignKey("DeliveryMan")] public int DeliveryManId { get; set; }
    }
}
