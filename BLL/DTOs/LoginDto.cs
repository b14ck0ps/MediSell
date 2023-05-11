using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Invalid Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid Enter password")]
        public string Password { get; set; }
    }
}