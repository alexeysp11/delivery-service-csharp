# notifyproductqtychanges 

[English](notifyproductqtychanges.md) | [Русский](notifyproductqtychanges.ru.md)

Warehouse client application: notify about changes in product quantity.

The scenario responsible for notifying about changes in product quantity involves monitoring inventory levels and sending notifications to relevant parties when certain thresholds are reached. 
This could be executed automatically through the inventory management software or started manually by warehouse employees.

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

## Process description

The overall description of the scenario for notifying about changes in product quantity in the warehouse backend service is that it allows warehouse staff to receive alerts when inventory levels reach a certain threshold or when products are running low. 

The interactive steps within the scenario include setting up notification preferences, receiving alerts, and updating inventory records as needed.

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- Set up notification preferences, such as choosing which products to receive alerts for and how often to receive them
- The system monitors the inventory database for any changes in product quantity.
- If a change is detected, the system sends a notification to the warehouse employee responsible for that product.
- The warehouse employee receives the notification and updates the inventory database accordingly.
    - Receive alerts when inventory levels reach a certain threshold or when products are running low
    - Update inventory records as needed, such as ordering more products or adjusting storage locations

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)

## Data 

### Objects

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Ingredient.md)
- Warehouse
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)

### DTOs

- ProductDTO
- IngredientDTO
- WarehouseDTO
- EmployeeDTO
