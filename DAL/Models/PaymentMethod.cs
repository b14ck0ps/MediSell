using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class PaymentMethod
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Payment Method Name")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Balance")]
        public decimal Balance { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Due")]
        public decimal Due { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please Enter a Positive Paid")]
        public decimal Paid { get; set; }

        //Foreign Key
        [ForeignKey("User")] public int UserId { get; set; }

        [ForeignKey("Order")] public int OrderId { get; set; }

        //Navigation Properties
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}