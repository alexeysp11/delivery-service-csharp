namespace DeliveryService.Models.Menu;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public MenuCategory MenuCategory { get; set; }
}