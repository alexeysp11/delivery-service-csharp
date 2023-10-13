using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Models.Orders;

public class PlaceOrderModel
{
    public int UserId { get; set; }
    public int Login { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public List<Product> Products { get; set; }
}