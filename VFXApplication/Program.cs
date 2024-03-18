using Microsoft.EntityFrameworkCore;
using VFXApplication;
using VFXApplication.Models;
using VFXApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // Retrieve ApiContext within the scope of an HTTP request
    var scopedServices = app.Services.CreateScope().ServiceProvider;
    var apiContext = scopedServices.GetRequiredService<ApiContext>();

    await next.Invoke();
});

// Adding some mockup data to in-memory database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApiContext>();
    UserService.AddTestData(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
