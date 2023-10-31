# preparemeal

[English](preparemeal.md) | [Русский](preparemeal.ru.md)

Kitchen client application: prepare order.

The prepare food scenario in the delivery service app involves retrieving the order details from the database, calculating the required ingredients and cooking instructions, and preparing the food according to those instructions. 
The app updates the status of the order as it is prepared and notifies the kitchen staff when it is ready for delivery.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [client application](../../frontend/kitchenclient.md), [backend service](../../backend/kitchenbackend.md)

## Process description

- This process is called from the [preprocessorder](../customer/preprocessorder.md) process.

![delivering_overall](../../img/delivering_overall.png)

### Step-by-step execution

- A customer places an order through the delivery service app.
- After some steps the order is finally received by the backend service for kitchen.
- Kitchen staff review the order and begin preparing the food.
- As the food is being prepared, the status of the order is updated in real-time on the app.
- Once the food is ready, kitchen staff update the order status to "ready for pickup" or "out for delivery".
- Delivery drivers receive the order details and pickup location through the app.
- Delivery drivers pick up the food and deliver it to the customer.

![kitchen.preparemeal](../../img/activitydiagrams/kitchen.preparemeal.png)
