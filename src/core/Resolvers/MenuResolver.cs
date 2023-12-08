using System.Data;
using System.Linq;
using Cims.WorkflowLib.DbConnections;
using Cims.WorkflowLib.Models.Business.Products;

namespace DeliveryService.Core.Resolvers;

/// <summary>
/// Menu resolver.
/// </summary>
public class MenuResolver
{
    private PgDbConnection PgDbConnection { get; }
    private string ConnectionString { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public MenuResolver()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
    }

    /// <summary>
    /// Method for getting menu.
    /// </summary>
    public ICollection<Product> GetMenu()
    {
        // 
        var categories = new List<ProductCategory>();
        var menuItems = new List<Product>();
        // 
        var dtCategories = GetCategories();
        foreach (DataRow row in dtCategories.Rows)
        {
            if (long.TryParse(row["delivery_category_cc_id"].ToString(), out long id))
            {
                categories.Add(new ProductCategory
                {
                    Id = id,
                    Name = row["category_name"].ToString(),
                    Description = row["category_description"].ToString(),
                    Products = new List<Product>(),
                    PictureUrl = row["picture_url"].ToString(),
                    PictureDescription = row["picture_description"].ToString()
                });
            }
        }
        //
        var dtMenuItems = GetMenuItems();
        foreach (DataRow row in dtMenuItems.Rows)
        {
            if (long.TryParse(row["delivery_category_cc_id"].ToString(), out long categoryId) 
                && long.TryParse(row["delivery_menuitem_cc_id"].ToString(), out long id)
                && decimal.TryParse(row["menu_item_price"].ToString(), out decimal itemPrice))
            {
                var category = categories.Where(x => x.Id == categoryId).First();
                var mi = new Product
                {
                    Id = id,
                    Name = row["menu_item_name"].ToString(),
                    Description = row["menu_item_description"].ToString(),
                    Price = itemPrice,
                    ProductCategory = category,
                    PictureUrl = row["picture_url"].ToString(),
                    PictureDescription = row["picture_description"].ToString()
                };
                menuItems.Add(mi);
                category.Products.Add(mi);
            }
        }
        return menuItems;
    }

    /// <summary>
    /// Method for getting menu categories.
    /// </summary>
    private DataTable GetCategories()
    {
        string sql = @$"-- 
select 
	dcc.delivery_category_cc_id,
	dcc.""name"" as category_name,
	dcc.description as category_description,
    dcc.picture_url,
    dcc.picture_description
from delivery_category_cc dcc
;";
        return PgDbConnection.ExecuteSqlCommand(sql).DataTableResult;
    }

    /// <summary>
    /// Method for getting menu items.
    /// </summary>
    private DataTable GetMenuItems()
    {
        string sql = @$"-- 
select 
	dmc.delivery_menuitem_cc_id,
	dmc.delivery_category_cc_id,
	dmc.""name"" as menu_item_name,
	dmc.description as menu_item_description,
	to_char(dmc.price, '999G999G999G990D90') as menu_item_price,
    dmc.picture_url,
    dmc.picture_description
from delivery_menuitem_cc dmc
order by dmc.delivery_menuitem_cc_id, dmc.delivery_category_cc_id
;";
        return PgDbConnection.ExecuteSqlCommand(sql).DataTableResult;
    }
}