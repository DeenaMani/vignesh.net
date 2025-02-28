using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyIncomeExpenseApp.Filters
{
    public class CheckSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the session contains the "Username" key
            string userEmail = context.HttpContext.Session.GetString("Username");

            // If not found, redirect to the login page
            if (string.IsNullOrEmpty(userEmail))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
