using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VFXApplication.Services
{
	public class RedirectFilter : IActionFilter
	{
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated && (context.HttpContext.Request.Path == "/User/Login" || context.HttpContext.Request.Path == "/"))
            {
                context.Result = new RedirectResult("/Forex/Index"); // Redirect authenticated users away from the login page
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after action execution
        }
    }
}

