using System.Collections.Generic;

namespace DeliveryService.Models.Menu;

public class MenuCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<MenuItem> MenuItems { get; set; }
    public string PictureUrl { get; set; }
    public string PictureDescription { get; set; }
}