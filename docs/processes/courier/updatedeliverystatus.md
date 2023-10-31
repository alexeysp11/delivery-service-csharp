# updatedeliverystatus

[English](updatedeliverystatus.md) | [Русский](updatedeliverystatus.ru.md)

Courier client application: update delivery status.

The scenario responsible for updating order status after delivering by couriers involves using the mobile app or web interface to update the status of the order from "out for delivery" to "delivered" and providing any relevant details about the delivery.

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md)

## Process description

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier updates the status of the delivery order (e.g. "en route", "delivered") in the system.
- The system updates the status of the delivery order and notifies the customer of any changes.
