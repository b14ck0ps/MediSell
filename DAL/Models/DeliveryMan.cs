using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class DeliveryMan
    {
        [Key] public int Id { get; set; }
        public bool Status { get; set; }
        public int TotalDelivery { get; set; }

        public decimal TotalEarning { get; set; }

        // Foreign Key
        [ForeignKey("User")] public int UserId { get; set; }

        // Navigation Property
        public virtual User User { get; set; }
        protected virtual ICollection<DeliveryStatus> DeliveryStatuses { get; set; } = new List<DeliveryStatus>();
    }
}