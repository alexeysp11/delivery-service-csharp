using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Models.AppSettings;
using DeliveryService.Core.Contexts;
using DeliveryService.Frontend.Courier.BL.Controllers;

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
builder.Services.AddScoped<CourierClientController>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
