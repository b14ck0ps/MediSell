using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CompanyDto
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Company Address")]
        public string Address { get; set; }
    }
}
