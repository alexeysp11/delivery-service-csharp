# fromkitchentowh

[English](fromkitchentowh.md) | [Русский](fromkitchentowh.ru.md)

Warehouse client application: deliver from kitchen to WH.

The scenario responsible for delivering products and ingredients from the kitchen to the warehouse by warehouse employees in the delivery service company involves receiving excess or unused ingredients from the kitchen staff, verifying their quality and quantity, storing them in the appropriate location in the warehouse, and updating inventory levels accordingly.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

## Process description

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- Warehouse employee opens the app.
- The employee selects the inventory they need to restock.
- The system checks if the inventory is available in the kitchen.
- If it is available, the system sends a notification to the kitchen employee to prepare it for delivery.
- When the inventory is ready, the kitchen employee delivers it to the warehouse.
