using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFXApplication.Models;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VFXApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiContext _context;
        public UserController(ApiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Login(string clientId, string userId, string password)
        {

            var user = await _context.Accounts.Where(
                x => x.ClientID == clientId && 
                x.UserID == userId && 
                x.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            Response.Cookies.Append("userId", userId);

            return Redirect("../Forex");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
