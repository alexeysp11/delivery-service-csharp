# deliverorder

Read this in other languages: [English](deliverorder.md), [Russian/Русский](deliverorder.ru.md). 

Courier client application: deliver order.

The scenario responsible for delivering order to customer by couriers involves using a mobile app or GPS-enabled device to navigate to the customer's location, delivering the order in a timely and professional manner, and obtaining any necessary signatures or other proof of delivery.

Related modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md).

## Process description

- Registration of the consumer's order using a QR code: start/end of work with the order.
- Information on orders carried/carried by the courier (order number, place of delivery, actual/estimated time of delivery).
- Building the most optimal route for delivery.
- Display the location of the courier on the map.

### Step-by-step execution

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier navigates to the delivery address using the app's map feature.
- The courier delivers the order to the customer and obtains a signature or confirmation code.
- The courier marks the delivery order as complete in the system.

![courier.deliverorder](../../img/activitydiagrams/courier.deliverorder.png)
