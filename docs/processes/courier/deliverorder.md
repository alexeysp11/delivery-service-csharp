# courier.deliverorder

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

![courier.deliverorder](../../img/activitydiagrams/courier.deliverorder.png)
