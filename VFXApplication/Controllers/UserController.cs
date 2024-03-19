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
        private readonly ILogger<UserController> _logger;

        public UserController(ApiContext context, IUserService userService, ILogger<UserController> logger)
        {
            _context = context;
            _userService = userService;
            _logger = logger;
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
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        // Making sure that the ModelState is being populated with the validation errors.
                        _logger.LogError($"Model error: {modelError.ErrorMessage}");
                    }
                    // Returns the validation errors if ModelState is invalid.
                    return BadRequest(ModelState);
                }

                // Attempt to login user
                var (principal, errorMessage) = await _userService.LoginAsync(_context, account.ClientID, account.UserID, account.Password);

                // Checking if the "login" claim is populated
                if (principal != null)
                {
                    // Sign in user
                    await HttpContext.SignInAsync(principal);
                    // Return success response with redirect url to be used on the view
                    return Json(new { redirectUrl = Url.Action("Index", "Forex") });
                }

                // If login fails, add model-level error message
                ModelState.AddModelError(string.Empty, errorMessage);

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex}");
                return StatusCode(500, "An unexpected error occurred. Plase try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "User");
        }
    }
}
