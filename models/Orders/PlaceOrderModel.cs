using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Orders;

/// <summary>
/// Model for placing order, that is used to send request from frontend to the controller.
/// </summary>
public class PlaceOrderModel
{
    /// <summary>
    /// User GUID.
    /// </summary>
    public string? UserUid { get; set; }
    
    /// <summary>
    /// Login of the user.
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// Phone number of the user.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// City of the delivery.
    /// </summary>
    public string? City { get; set; }
    
    /// <summary>
    /// Address of the delivery.
    /// </summary>
    public string? Address { get; set; }
    
    /// <summary>
    /// List of the product IDs, that user has placed into the order.
    /// </summary>
    public List<int> ProductIds { get; set; }
    
    /// <summary>
    /// List of the products, that user has placed into the order.
    /// </summary>
    public List<Product> Products { get; set; }
}