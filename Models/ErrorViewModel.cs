using System.ComponentModel.DataAnnotations;
namespace MyIncomeExpenseApp.Models
{

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

   public class User
    {
        /* Unique identifier for the user (This is generally required by the database) */
        public int UserID { get; set; }

        /* Username is required and cannot be an empty string */
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; } = string.Empty;

        /* Password is required and cannot be empty */
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        public string Password { get; set; } = string.Empty;

        /* Email is optional, but if provided, it should be a valid email address */
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        /* CreatedAt is automatically set, but you can add a required validation if needed */
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}