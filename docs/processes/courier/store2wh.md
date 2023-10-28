# courier.store2wh

Read this in other languages: [English](store2wh.md), [Russian/Русский](store2wh.ru.md). 

Courier client application: deliver order from store to WH

Related modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md).

## Process description


### Step-by-step execution

- The notification comes to the backend service of the courier application.
- Working with a kitchen order: receiving a request with a list of products to buy, the location of the nearest store with the best prices, a receipt photo.
- Information on orders carried/carried by the courier (order number, place of delivery, actual/estimated time of delivery).
- Building the most optimal route for delivery.
- Display the location of the courier on the map.
