# kitchen2wh

[English](kitchen2wh.md) | [Русский](kitchen2wh.ru.md)

Name: **Deliver from kitchen to WH**.

The scenario responsible for delivering products and ingredients from the kitchen to the warehouse by warehouse employees in the delivery service company involves receiving excess or unused ingredients from the kitchen staff, verifying their quality and quantity, storing them in the appropriate location in the warehouse, and updating inventory levels accordingly.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

## Process description

![delivering_overall](../../img/delivering_overall.png)

### Step-by-step execution

- Warehouse employee opens the app.
- The employee selects the inventory they need to restock.
- The system checks if the inventory is available in the kitchen.
- If it is available, the system sends a notification to the kitchen employee to prepare it for delivery.
- When the inventory is ready, the kitchen employee delivers it to the warehouse.

## Data 

### Objects

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Ingredient.cs)
- [Warehouse](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Warehouse.cs) 
- Kitchen
    - The kitchen object could have properties such as name, location, capacity, and equipment. It could also have methods for adding or removing equipment, scheduling staff, and managing inventory.
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs)

### DTOs

- ProductDTO
- IngredientDTO
- WarehouseDTO
- KitchenDTO
- EmployeeDTO
