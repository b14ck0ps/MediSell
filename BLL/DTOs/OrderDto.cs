using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class OrderDto
    {
        [Key] public int Id { get; set; }
        public DateTime OderDate { get; set; }
        public decimal Total { get; set; }

        // Foreign Key
        [ForeignKey("User")] public int OrderedBy { get; set; }
    }
}
