using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.AppSettings;
using DeliveryService.Core.Contexts;
using DeliveryService.Core.Resolvers;
using DeliveryService.Frontend.Customer.BL.Controllers;

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
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly("DeliveryService.Core")));
builder.Services.AddScoped<CustomerClientControllerBL>();
builder.Services.AddScoped<MenuResolver>();

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
