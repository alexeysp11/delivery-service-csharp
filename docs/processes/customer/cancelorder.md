# cancelorder

[English](cancelorder.md) | [Русский](cancelorder.ru.md)

Customer client application: cancel order.

The cancel order scenario in the delivery service app involves allowing customers to cancel their order before it is prepared and delivered. 
The app prompts the user to confirm their cancellation and provides options for leaving feedback or comments.

Macro process: [requesting](../../macroprocesses/requesting.md)

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md)

Infuences on: 
- [notificationsbackend](../../backend/notificationsbackend.md)
    - [sendnotifications](../notificationsbackend/sendnotifications.md)

## Process description

- Some orders cannot be cancelled:
    - status:
        - "In delivery",
        - "In cooking";
        - "WH employee started working" (internal filter, the user never sees it).
        - "On delivery from the store to the warehouse" (internal filter, the user never sees it).
    - type of payment:
        - not "cash on delivery",
        - not "through the validator upon receipt".
- If, when loading the order card, it is already known that the order cannot be canceled, then hide the "Cancel order" button.
- After canceling an order, the order disappears from the list of current orders.

This process cancels the macroprocess [delivering](../../macroprocesses/delivering.md):

![delivering_overall](../../img/delivering_overall.png)

However, this process is implemented as part of the microprocess [requesting](../../macroprocesses/requesting.md):

![requesting_overall](../../img/requesting_overall.png)

### Step-by-step execution

- The user opens the [Pending orders](pendingorders.md) or [All orders](orders.md) page.
- The user selects an order they want to cancel, or opens the order page.
- The user clicks the "Cancel order" button.
- The [client-side app](../../frontend/customerclient.md) checks if the order can be cancelled.
    - If the order cannot be cancelled, the [client-side app](../../frontend/customerclient.md) prompts the message "The order cannot be cancelled becase the order is already in delivery".
    - If the order can be cancelled, the [client-side app](../../frontend/customerclient.md) redirects request to the [customerbackend](../../backend/customerbackend.md) service.
- The [customerbackend](../../backend/customerbackend.md) service checks if the order can be cancelled.
- If the status of the order has changed or doesn't allow to cancel the order, then update the data in the DB, display the message "The order cannot be canceled due to a status mismatch" and update the order status.
- If the order status allows you to cancel the order, then perform the following steps:
    - update the data in the DB, 
    - notify the [warehousebackend](../../backend/warehousebackend.md) service, so that the employee cannot take the order for execution,
    - notify the WH employee that is responsible for checking quantity of the ingredients, as well as their supervisor, 
    - display the message "Order successfully canceled",
    - update the page.

![customer.cancelorder](../../img/activitydiagrams/customer.cancelorder.png)

## Data

### Objects 

- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)
- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)

### DTOs 

- OrderDTO 
- UserDTO

### Database tables 

- [delivery_employee_whb](../../dbtables/warehouse/delivery_employee_whb.md)
- [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md)
- [delivery_category_cb](../../dbtables/customer/delivery_category_cb.md)
- [delivery_order_cb](../../dbtables/customer/delivery_order_cb.md)
