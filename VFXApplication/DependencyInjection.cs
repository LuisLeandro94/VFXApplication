using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VFXApplication.Models;
using VFXApplication.Services;
using VFXFinancial.Services;

namespace VFXApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IForexRequestService, ForexRequestService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<HttpClientService>();
            services.AddTransient<HttpClient>();
            services.AddHttpContextAccessor();

            services.AddDbContext<ApiContext>(options =>
            options.UseInMemoryDatabase("VFXApplication"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User";
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            return services;
        }
    }
}
