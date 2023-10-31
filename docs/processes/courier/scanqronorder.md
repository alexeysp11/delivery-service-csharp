# scanqronorder

Read this in other languages: [English](scanqronorder.md), [Russian/Русский](scanqronorder.ru.md). 

Courier client application: scan QR code on order.

The scenario responsible for scanning QR code on order before delivering by couriers involves using a mobile app or handheld scanner to scan a unique QR code associated with each order. 
This verifies that the correct order is being delivered and provides real-time tracking information to the delivery service company and the customer.

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md).

## Process description

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier scans the QR code on the delivery order using their device's camera.
- The system verifies the QR code and displays the details of the delivery order to the courier.
