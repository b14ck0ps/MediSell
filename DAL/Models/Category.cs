using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Category Description")]
        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}