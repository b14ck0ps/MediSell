using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Company
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Company Address")]
        public string Address { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}