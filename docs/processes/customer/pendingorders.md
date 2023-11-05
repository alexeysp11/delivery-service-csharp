# pendingorders

[English](pendingorders.md) | [Русский](pendingorders.ru.md)

Name: **pending orders**.

The overall description of the scenario for tracking an order in the customer backend service is that it allows customers to monitor the progress of their order from processing to delivery. 

The interactive steps within the scenario include viewing order status updates in real-time, tracking the courier's location on a map, and receiving notifications when the order is out for delivery or has been delivered.

Macro process: [information](../../macroprocesses/information.md)

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md)

## Process description

This process almost completely repeats [viewing all orders](../customer/orders.md), except that orders are filtered by status to be displayed on this form: it is necessary that it be "Processing", "In the process of cooking", "In delivery".

![information_overall](../../img/information_overall.png)

### Step-by-step execution

See [viewing all orders](../customer/orders.md).

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Data

### Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)

### Database tables 

- [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md)
- [delivery_category_cb](../../dbtables/customer/delivery_category_cb.md)
- [delivery_order_cb](../../dbtables/customer/delivery_order_cb.md)
