using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VFXApplication.Models;
using VFXFinancial.Models;

namespace VFXApplication.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string clientId, string userId, string password);
        Task<AccountModel?> ValidateUserAsync(ApiContext context, string clientId, string userId, string password);
        Task<(ClaimsPrincipal?, string)> LoginAsync(ApiContext context, string clientId, string userId, string password);
    }
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string clientId, string userId, string password)
        {
            try
            {
                if (clientId == null || userId == null || password == null)
                {
                    throw new ArgumentNullException("One or more input parameters are null.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static void AddTestData(ApiContext context)
        {
            try
            {
                var testAccount = new AccountModel
                {
                    Id = "1",
                    ClientID = "admin",
                    UserID = "admin",
                    Password = "vfxfinancial"
                };

                context.Accounts.Add(testAccount);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public async Task<AccountModel?> ValidateUserAsync(ApiContext context, string clientId, string userId, string password)
        {
            try
            {
                var account = await context.Accounts
                    .Where(x => x.ClientID == clientId &&
                                x.UserID == userId &&
                                x.Password == password)
                    .FirstOrDefaultAsync();

                return account;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public async Task<(ClaimsPrincipal?, string)> LoginAsync(ApiContext context, string clientId, string userId, string password)
        {
            try
            {
                var user = await ValidateUserAsync(context, clientId, userId, password);

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserID)
                    };

                    var identity = new ClaimsIdentity(claims, "login");
                    return (new ClaimsPrincipal(identity), null);
                }
                else
                {
                    return (null, "Invalid credentials.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while logging in: " + ex.Message);
                return (null, "An error occurred while logging in");
            }
        }
    }
}
