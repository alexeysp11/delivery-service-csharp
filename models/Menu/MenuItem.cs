using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Menu;

/// <summary>
/// Menu item (product).
/// </summary>
public class MenuItem : Product 
{
    /// <summary>
    /// Category of a menu item.
    /// </summary>
    public MenuCategory MenuCategory { get; set; }
}