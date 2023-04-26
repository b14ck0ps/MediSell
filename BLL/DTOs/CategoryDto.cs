using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDto
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Category Description")]
        public string Description { get; set; }

    }
}
