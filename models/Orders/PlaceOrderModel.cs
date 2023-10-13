using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Orders;

/// <summary>
/// 
/// </summary>
public class PlaceOrderModel
{
    /// <summary>
    /// 
    /// </summary>
    public string? UserUid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? City { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Address { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public List<int> ProductIds { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public List<Product> Products { get; set; }
}