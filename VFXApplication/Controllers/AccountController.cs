using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VFXFinancial.Models;

namespace VFXFinancial.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public IActionResult Login(AccountModel model)
        {
            if (model.ClientID == "admin" && model.UserID == "admin" && model.Password == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VFXFinancial2024"));
                var loginCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "Luis",
                    audience: "https://localhost:7291",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: loginCredentials
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = token });
            } else
            {
                return Unauthorized();
            }
        }
    }
}
