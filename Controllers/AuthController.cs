using Microsoft.AspNetCore.Mvc;
using MyIncomeExpenseApp.Models;
using MyIncomeExpenseApp.Data;

namespace MyIncomeExpenseApp.Controllers;
public class AuthController(DatabaseHelper dbHelper) : Controller
{
    private readonly DatabaseHelper _dbHelper = dbHelper;

    // Display login form
    [HttpGet]
    public IActionResult Login()
    {
        string? userEmail = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(userEmail)) 
        {
             return RedirectToAction("Index", "Home");
        }
        return View(new LoginModel());
    }

    // Handle login form submission
    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        string? userEmail = HttpContext.Session.GetString("Username");
        if (!string.IsNullOrEmpty(userEmail)) 
        {
            return RedirectToAction("Dashboard", "Home");
        }
        // Validate the model first
        if (ModelState.IsValid)
        {
            // Here you would typically fetch user data from your database.
            var user = _dbHelper.GetUsers().FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                // Invalid login, show error
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }

        // If the model is not valid or login fails, show the login form with errors
        return View(model);
    }
        
    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); 
        return RedirectToAction("Login");
    }
}

