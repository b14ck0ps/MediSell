using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }
        public DateTime OderDate { get; set; }
        public decimal Total { get; set; }

        // Foreign Key
        [ForeignKey("User")] public int OrderedBy { get; set; }

        // Navigation Property
        public virtual User User { get; set; }
        protected virtual ICollection<DeliveryStatus> DeliveryStatuses { get; set; } = new List<DeliveryStatus>();
        protected virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
        protected virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
    }
}