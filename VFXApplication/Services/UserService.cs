using VFXApplication.Models;
using VFXFinancial.Models;

namespace VFXApplication.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string clientId, string userId, string password);
    }
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string clientId, string userId, string password)
        {
            if (clientId == null || userId == null || password == null) {
                return false;
            }
            return true;
        }

        public static void AddTestData(ApiContext context)
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
    }
}
