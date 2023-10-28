# prepareorderkitchen

Read this in other languages: [English](prepareorderkitchen.md), [Russian/Русский](prepareorderkitchen.ru.md). 

Kitchen client application: prepare order.

Related modules: [client application](../../frontend/kitchenclient.md), [backend service](../../backend/kitchenbackend.md).

## Process description

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- A customer places an order through the delivery service app.
- After some steps the order is finally received by the backend service for kitchen.
- Kitchen staff review the order and begin preparing the food.
- As the food is being prepared, the status of the order is updated in real-time on the app.
- Once the food is ready, kitchen staff update the order status to "ready for pickup" or "out for delivery".
- Delivery drivers receive the order details and pickup location through the app.
- Delivery drivers pick up the food and deliver it to the customer.
