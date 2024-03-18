using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFXApplication.Models;
using VFXApplication.Services.RedirecAuthenticatedUsers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using VFXApplication.Services;
using VFXFinancial.Services;

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
        public async Task<IActionResult> Login(string clientId, string userId, string password)
        {

            var user = await _userService.ValidateUserAsync(_context, clientId, userId, password);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserID)
                };

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Forex");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "User");
        }
    }
}
