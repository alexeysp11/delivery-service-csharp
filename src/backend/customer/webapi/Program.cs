using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.AppSettings;
using DeliveryService.Backend.Customer.BL.Controllers;
using DeliveryService.Core.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CustomerBackendControllerBL>();
builder.Services.AddDbContext<DeliveringContext>(options =>
        options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicecustomer;Username=postgres;Password=postgres", 
            b => b.MigrationsAssembly("DeliveryService.Backend.Customer.Webapi")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
