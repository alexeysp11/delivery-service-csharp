# notifyproductqtychanges 

[English](notifyproductqtychanges.md) | [Русский](notifyproductqtychanges.ru.md)

Name: **Notify about changes in product quantity**.

The scenario responsible for notifying about changes in product quantity involves monitoring inventory levels and sending notifications to relevant parties when certain thresholds are reached. 
This could be executed automatically through the inventory management software or started manually by warehouse employees.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

Depends on: 
- [adminbackend](../../backend/adminbackend.md): this process is called automatically or by trigger from this backend service

Infuences on: 
- [notificationsbackend](../../backend/notificationsbackend.md)
    - [sendnotifications](../notificationsbackend/sendnotifications.md)

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

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Ingredient.cs)
- [Warehouse](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Warehouse.cs) 
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs)

### DTOs

- ProductDTO
- IngredientDTO
- WarehouseDTO
- EmployeeDTO
