using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.AppSettings;
using DeliveryService.Core.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Access/SignIn";
        options.ExpireTimeSpan = System.TimeSpan.FromHours(12);
    });
builder.Services.AddSingleton<NetworkAppSettings>(settings => 
        new NetworkAppSettings
        {
            ServerAddress = builder.Configuration["NetworkAppSettings:ServerAddress"],
            Environment = builder.Configuration["NetworkAppSettings:Environment"]
        }
    );
builder.Services.AddDbContext<DeliveringContext>(options =>
        options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicecustomer;Username=postgres;Password=postgres", 
            b => b.MigrationsAssembly("DeliveryService.Core")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=SignIn}/{id?}");

app.Run();
