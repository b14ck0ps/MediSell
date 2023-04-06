using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class DeliveryStatus
    {
        [Key] public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Status { get; set; }
        public int Report { get; set; }

        // Foreign Key
        [ForeignKey("Order")] public int OrderId { get; set; }

        [ForeignKey("DeliveryMan")] public int DeliveryManId { get; set; }

        // Navigation Property
        public DeliveryMan DeliveryMan { get; set; }
        public Order Order { get; set; }
    }
}