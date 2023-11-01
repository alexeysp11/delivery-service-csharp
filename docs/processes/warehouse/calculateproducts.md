# calculateproducts

[English](calculateproducts.md) | [Русский](calculateproducts.ru.md)

Warehouse client application: calculate products.

The scenario responsible for calculating products stored in the warehouse by warehouse employees in the delivery service company involves using inventory management software to track incoming shipments, outgoing orders, and current stock levels. 
This allows warehouse employees to accurately calculate how much of each product is available at any given time and make informed decisions about ordering and restocking.

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

## Process description

The overall description of the scenario for calculating product quantities in the warehouse backend service is that it allows warehouse staff to track inventory levels and ensure that there is enough stock on hand to fulfill orders. 

The interactive steps within the scenario include scanning product barcodes, entering product quantities, and updating inventory records.

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- Warehouse employee opens the app.
- The employee selects the product they want to calculate.
- The system checks the inventory database for that product.
- The system displays the current stock of that product to the employee.
- Scan product barcodes to identify the products in the warehouse
- Enter the quantity of each product on hand
- Update inventory records to reflect the new product quantities

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)

## Data

### Objects

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- Warehouse 

### DTOs

- ProductDTO
- WarehouseDTO
