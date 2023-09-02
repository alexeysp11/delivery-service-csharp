# customer.cancelorder

Read this in other languages: [English](customer.cancelorder.md), [Russian/Русский](customer.cancelorder.ru.md). 

Customer client application: cancel order.

The description of the client application is presented at [this link](../customerclient.md).

## Process description

- Some orders cannot be cancelled:
    - status:
        - "In delivery",
        - "In cooking";
        - "On delivery from the store to the warehouse" (internal filter, the user never sees it).
    - type of payment:
        - "cash on delivery",
        - "through the validator upon receipt".
- If, when loading the order card, it is already known that the order cannot be canceled, then hide the "Cancel order" button.
- After canceling an order, the order disappears from the list of current orders.

## Sequence of user actions

![customer.cancelorder](../../img/customer.cancelorder.png)

- The user opens the "Pending orders" or "All orders" page.
- The user opens the order page.
- The user clicks the "Cancel order" button:
    - On the backgrand, a request is made to the service to check whether the status of the order has changed.
    - If the status of the order has changed, then update the data in the database of the client application, display the message "The order cannot be canceled due to a status mismatch: < status name >" and kick the user to "Current orders".
    - If the order status allows you to cancel the order, then update the data in the database of the client application, display the message "Order successfully canceled" and kick the user to the main menu.