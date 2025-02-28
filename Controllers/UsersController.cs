using Microsoft.AspNetCore.Mvc;
using MyIncomeExpenseApp.Models;
using MyIncomeExpenseApp.Data;
using System.Linq;
using MyIncomeExpenseApp.Filters;

namespace MyIncomeExpenseApp.Controllers;

    public class UsersController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public UsersController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Display the list of users
        [HttpGet]
        [ServiceFilter(typeof(CheckSessionAttribute))]
        public IActionResult Index()
        {
            var users = _dbHelper.GetUsers();  // Fetch all users from the database
            return View(users);  // Pass the list to the view
        }

        // Display form to create a new user
    //     [HttpGet]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult Create()
    //     {
    //         return View(new UserModel());  // Return an empty User object for the form
    //     }

    //     // Handle form submission to create a new user
    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult Create(UserModel model)
    //     {
    //         // Validate the model
    //         if (ModelState.IsValid)
    //         {
    //             // Check if the username already exists
    //             if (_dbHelper.GetUsers().Any(u => u.Username == model.Username))
    //             {
    //                 ModelState.AddModelError("Username", "Username already exists.");
    //                 return View(model);
    //             }

    //             // Save the new user in the database
    //             _dbHelper.AddUser(model);  
    //             return RedirectToAction(nameof(Index));  // Redirect to the user list after successful creation
    //         }

    //         return View(model);  // If model is invalid, return the view with the validation errors
    //     }

    //     // Display the edit form for an existing user
    //     [HttpGet]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult Edit(int id)
    //     {
    //         var user = _dbHelper.GetUsers().FirstOrDefault(u => u.Id == id);

    //         if (user == null)
    //         {
    //             return NotFound();  // If the user is not found, return 404
    //         }

    //         return View(user);  // Pass the user data to the edit form
    //     }

    //     // Handle the form submission to update an existing user
    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult Edit(int id, UserModel model)
    //     {
    //         // Check if the user ID is valid
    //         if (id != model.Id)
    //         {
    //             return NotFound();  // If the IDs don't match, return 404
    //         }

    //         // Validate the model
    //         if (ModelState.IsValid)
    //         {
    //             var existingUser = _dbHelper.GetUsers().FirstOrDefault(u => u.Id == id);

    //             if (existingUser == null)
    //             {
    //                 return NotFound();  // If user does not exist, return 404
    //             }

    //             // Update user details
    //             existingUser.Username = model.Username;
    //             existingUser.Email = model.Email;
    //             existingUser.Password = model.Password; // Remember to hash the password in real app
    //             existingUser.IsActive = model.IsActive;

    //             _dbHelper.UpdateUser(existingUser);  // Save the updated user to the database
    //             return RedirectToAction(nameof(Index));  // Redirect to the user list after successful update
    //         }

    //         return View(model);  // Return the view with validation errors if model is invalid
    //     }

    //     // Display the delete confirmation page for a user
    //     [HttpGet]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult Delete(int id)
    //     {
    //         var user = _dbHelper.GetUsers().FirstOrDefault(u => u.Id == id);

    //         if (user == null)
    //         {
    //             return NotFound();  // Return 404 if user is not found
    //         }

    //         return View(user);  // Pass user data to the delete confirmation page
    //     }

    //     // Handle the actual deletion of the user
    //     [HttpPost, ActionName("Delete")]
    //     [ValidateAntiForgeryToken]
    //     [ServiceFilter(typeof(CheckSessionAttribute))]
    //     public IActionResult DeleteConfirmed(int id)
    //     {
    //         var user = _dbHelper.GetUsers().FirstOrDefault(u => u.Id == id);

    //         if (user == null)
    //         {
    //             return NotFound();  // Return 404 if user is not found
    //         }

    //         _dbHelper.DeleteUser(user);  // Delete the user from the database
    //         return RedirectToAction(nameof(Index));  // Redirect to the user list after successful deletion
    //     }
    }

