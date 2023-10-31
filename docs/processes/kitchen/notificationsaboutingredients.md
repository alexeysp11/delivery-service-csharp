# notificationsaboutingredients

Read this in other languages: [English](notificationsaboutingredients.md), [Russian/Русский](notificationsaboutingredients.ru.md). 

Kitchen client application: get notifications about ingredients.

The ingredient delivery notification scenario in the delivery service app involves notifying kitchen employees when necessary ingredients for an order have been delivered to the kitchen. 
This allows them to begin preparing the order promptly and ensures that all necessary ingredients are available.

Related modules: [client application](../../frontend/kitchenclient.md), [backend service](../../backend/kitchenbackend.md).

## Process description

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- Kitchen employee opens the app.
- The system checks the delivery order and identifies the necessary ingredients.
- If the ingredients are not available in the kitchen, the system sends a notification to the warehouse to deliver them.
- When the ingredients are delivered, the system sends a notification to the kitchen employee.
