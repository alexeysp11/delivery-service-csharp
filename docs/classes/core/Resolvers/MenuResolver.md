# MenuResolver Class 

Namespace: [DeliveryService.Core.Resolvers](DeliveryService.Core.Resolvers.md)

Menu resolver.

## Constructors 

### MenuResolver()

Default constructor.

```C#
public MenuResolver();
```

## Methods 

### GetMenu()

Method for getting menu.

```C#
public ICollection<MenuItem> GetMenu();
```

#### Returns

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[MenuItem](../../models/Menu/MenuItem.md)>

Collection of menu items.

#### Examples

Example of using `GetMenu()` method:

```C#
    IEnumerable<MenuItem> menuItems = new List<MenuItem>();
    IEnumerable<MenuCategory> categories = new List<MenuCategory>();
    try
    {
        menuItems = new MenuResolver().GetMenu();
        categories = menuItems.Select(x => x.MenuCategory).Distinct();
    }
    catch (System.Exception ex)
    {
        ViewData["placing_order"] = "ERROR: " + ex.Message;
    }
```
