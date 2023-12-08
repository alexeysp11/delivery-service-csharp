using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Orders;

/// <summary>
/// Model for transferring a finished order from the kitchen to the warehouse (shipping point, destination, start time, end time, products, order number, generated order QR code)
/// </summary>
public class DeliveryKitchen2Wh : DeliveryOperation
{
    /// <summary>
    /// 
    /// </summary>
    public string OrderNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string GeneratedOrderQrCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ICollection<Product> Products { get; set; }
}
