using System;
using System.ComponentModel.DataAnnotations;

namespace MyIncomeExpenseApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }  // Primary Key

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }  // User's Username

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }  // User's Email

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }  // User's Password (encrypted in a real app)

        public DateTime DateCreated { get; set; }  // Date when user was created

        public bool IsActive { get; set; }  // To track if user is active or not
    }
}
