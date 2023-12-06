using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Orders;

/// <summary>
/// Model for transferring products from warehouse to kitchen (shipping point, destination, start time, end time, products, ingredients)
/// </summary>
public class DeliveryWh2Kitchen : DeliveryOperation
{
    /// <summary>
    /// 
    /// </summary>
    public ICollection<Product> Products { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ICollection<Ingredient> Ingredients { get; set; }
}
