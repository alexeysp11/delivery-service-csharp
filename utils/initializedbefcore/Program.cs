using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DeliveryService.Core.Contexts;
using DeliveryService.Utils.InitializeDbFfCore;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        // Instance of application.
        services.AddSingleton<IExampleInstance, ExampleInstance>();

        // DbContext.
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<DeliveringContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicecustomer;Username=postgres;Password=postgres", 
                    b => b.MigrationsAssembly("DeliveryService.Core"))
                .Options;
        });
    }).Build();

var app = _host.Services.GetRequiredService<IExampleInstance>();
app.Run();
