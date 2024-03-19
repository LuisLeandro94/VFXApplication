using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VFXApplication.Services
{
	public class RedirectFilter : IActionFilter
	{
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Checking if HttpContext and User aren't null
            if (context.HttpContext != null && context.HttpContext.User != null)
            {
                // Checking if the user is authenticated and Identity isn't null
                if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
                {
                    // Checking if the request path is the login page or the root URL
                    if (context.HttpContext.Request.Path == "/User/Login" || context.HttpContext.Request.Path == "/")
                    {
                        // Redirect authenticated users away from the login page
                        context.Result = new RedirectResult("/Forex/Index");
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after action execution
        }
    }
}

