using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFXApplication.Models;
using VFXApplication.Services.RedirecAuthenticatedUsers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using VFXApplication.Services;
using VFXFinancial.Services;
using VFXFinancial.Models;

namespace VFXApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiContext _context;
        private readonly IUserService _userService;

        public UserController(ApiContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        [RedirectAttribute]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the view with validation errors
                return View(account);
            }

            var (principal, errorMessage) = await _userService.LoginAsync(_context, account.ClientID, account.UserID, account.Password);
            if (principal != null)
            {
                await HttpContext.SignInAsync(principal);
                return Json(new { redirectUrl = Url.Action("Index", "Forex") });
            }

            // If login fails, add model-level error message
            ModelState.AddModelError(string.Empty, errorMessage);

            // Return the view with model containing errors
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "User");
        }
    }
}
