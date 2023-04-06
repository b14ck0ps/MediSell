using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Models.Enums;

namespace DAL.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [MaxLength(50, ErrorMessage = "First Name must be less than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name must be less than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Your Birth Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [Phone(ErrorMessage = "Please Enter a Valid Phone Number")]
        [RegularExpression(@"^(\+)?(\d{2})?0?(\d{10})$", ErrorMessage = "Please enter a valid 11-digit phone number")]
        public string Phone { get; set; }

        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        [MaxLength(100, ErrorMessage = "Address must be less than 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$",
            ErrorMessage =
                "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Required] public Role Role { get; set; }

        // Navigation property
        protected virtual ICollection<ProductsReview> ProductsReviews { get; set; } = new List<ProductsReview>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        protected virtual ICollection<DeliveryMan> DeliveryMen { get; set; } = new List<DeliveryMan>();
        protected virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}