# store2wh

[English](store2wh.md) | [Русский](store2wh.ru.md)

Courier client application: deliver order from store to WH.

The scenario responsible for delivering products from store to warehouse by couriers involves receiving requests for specific products from warehouse employees, locating those products in the store, packaging them for transport, and delivering them to the warehouse in a timely manner.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md)

## Process description

![delivering_overall](../../img/delivering_overall.png)

### Step-by-step execution

- The store manager creates a delivery order in the system.
- The system assigns a courier to the delivery order.
- The notification comes to the backend service of the courier application.
- The courier picks up the products from the store and loads them into their vehicle.
- Working with a kitchen order: receiving a request with a list of products to buy, the location of the nearest store with the best prices, a receipt photo.
- Information on orders carried/carried by the courier (order number, place of delivery, actual/estimated time of delivery).
- Building the most optimal route for delivery.
- The courier delivers the products to the warehouse.
- Display the location of the courier on the map.
- The courier marks the delivery order as complete in the system.

## Data 

### Objects

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- Store
    - Store object could have properties like name, location, inventory levels, etc. 
- Warehouse
    - Warehouse object could have properties like location, inventory levels, etc. 
- DeliveryOperation
    - References to product, employee (courier), starting point, destination.

### DTOs

- DeliveryDTO.
    - DeliveryDTO could have properties like storeName, warehouseLocation, courierName, deliveryDate, vehicle type, etc.
