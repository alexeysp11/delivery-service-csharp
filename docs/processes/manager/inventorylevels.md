# inventorylevels

[English](inventorylevels.md) | [Русский](inventorylevels.ru.md)

Name: **Set inventory levels**.

The scenario responsible for setting inventory levels by manager in the delivery service company involves determining optimal inventory levels based on demand forecasts, adjusting inventory levels as needed to avoid stockouts or excess inventory, and monitoring inventory levels to ensure efficient operations.

For this scenario, it is necessary to complete the approval chain (for example, *warehouse manager*, *financial analyst*, *CEO*).

Process pattern: [organizational](../../processpatterns/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [adminbackend](../../backend/adminbackend.md) | [dbreplication](../admin/dbreplication.md) |
| [warehousebackend](../../backend/warehousebackend.md) | [calculateproducts](../warehouse/calculateproducts.md) |
| [courierbackend](../../backend/courierbackend.md) | [store2wh](../courier/store2wh.md) |

## Process description

![organizational_overall](../../img/organizational_overall.png)

### Step-by-step execution

- Manager opens the app.
- Manager selects "Set Inventory Levels" option.
- The manager selects the option to set inventory levels.
- The app displays a list of available items, along with current inventory levels and reorder points.
- The manager can adjust inventory levels based on demand forecasts or supplier lead times.
- The system updates the inventory level in the database.
- The app automatically generates purchase orders for items that fall below the reorder point.
- The manager can review and approve purchase orders before they are sent to suppliers.

![manager.inventorylevels](../../img/activitydiagrams/manager.inventorylevels.png)

## Data structures

### Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs)
- Stock levels model: This model could include properties such as current stock levels and reorder points. It could also have methods for managing stock levels.
- [Company](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Company.cs): Supplier
- [ProductOffering](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/ProductOffering.cs)

### DTOs
