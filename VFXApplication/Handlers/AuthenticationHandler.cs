using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using VFXApplication.Models;

namespace VFXApplication.Handlers
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ApiContext _dbContext;

        public AuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ApiContext dbContenxt) : base(options, logger, encoder, clock)
        {
            _dbContext = dbContenxt;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Cookies.ContainsKey("userId"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var userId = Request.Cookies["userId"];

            var user = _dbContext.Accounts.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid user");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserID)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
