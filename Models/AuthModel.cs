using System.ComponentModel.DataAnnotations;
namespace MyIncomeExpenseApp.Models
{
    public class LoginModel
    {
        // Username and Password are required for login
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
