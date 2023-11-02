# deliverorder

[English](deliverorder.md) | [Русский](deliverorder.ru.md)

Courier client application: deliver order.

The scenario responsible for delivering order to customer by couriers involves using a mobile app or GPS-enabled device to navigate to the customer's location, delivering the order in a timely and professional manner, and obtaining any necessary signatures or other proof of delivery.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md)

## Process description

- Registration of the delivery order using a QR code: start/end of work with the order.
- Information on orders carried/carried by the courier (order number, place of delivery, actual/estimated time of delivery).
- Building the most optimal route for delivery.
- Display the location of the courier on the map.

![delivering_overall](../../img/delivering_overall.png)

### Step-by-step execution

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier registers the backpack and the order, launching the [scanbackpack](scanbackpack.md) and [scanqronorder](scanqronorder.md) processes.
- The [updatedeliverystatus](updatedeliverystatus.ru.md) process is launched in order to start delivery.
- The courier navigates to the delivery address using the app's map feature.
- The courier delivers the order to the customer and obtains a signature or confirmation code.
- The courier marks the delivery order as complete in the system.
- When the courier marks the order as completed, the [updatedeliverystatus](updatedeliverystatus.md) process is launched to complete delivery.

![courier.deliverorder](../../img/activitydiagrams/courier.deliverorder.png)

## Data

### Objects

- Order
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- DeliveryStatus

### DTOs

- DeliveryDTO
