using Microsoft.EntityFrameworkCore;
using VFXFinancial.Models;

namespace VFXApplication.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }

        public DbSet<AccountModel> Accounts { get; set; }
    }
}
