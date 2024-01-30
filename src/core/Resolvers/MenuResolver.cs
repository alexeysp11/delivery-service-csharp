using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.DbConnections;
using Cims.WorkflowLib.Models.Business.Products;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Core.Resolvers;

/// <summary>
/// Menu resolver.
/// </summary>
public class MenuResolver
{
    private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public MenuResolver(DbContextOptions<DeliveringContext> contextOptions)
    {
        _contextOptions = contextOptions;
    }

    /// <summary>
    /// Method for getting menu.
    /// </summary>
    public ICollection<Product> GetMenu()
    {
        using var context = new DeliveringContext(_contextOptions);
        var menuItems = context.Products
            .Include(x => x.ProductCategory)
            .Where(x => x.ProductCategory != null && x.ProductCategory.Description != "Ingredients")
            .ToList();
        return menuItems;
    }
}