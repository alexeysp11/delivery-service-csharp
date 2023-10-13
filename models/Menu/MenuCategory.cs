using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Menu;

/// <summary>
/// Menu category (product category).
/// </summary>
public class MenuCategory : ProductCategory
{
    /// <summary>
    /// Collection of menu items (products).
    /// </summary>
    public ICollection<MenuItem> MenuItems { get; set; }
}