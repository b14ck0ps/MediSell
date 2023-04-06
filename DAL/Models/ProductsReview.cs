using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductsReview
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Rating")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please Enter Comment")]
        [StringLength(500, ErrorMessage = "Comment cannot be longer than 500 characters.")]
        public string Comment { get; set; }

        // Foreign key
        [ForeignKey("Product")] public int ProductId { get; set; }
        [ForeignKey("User")] public int UserId { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}