# customerbackend.preprocessorder

Read this in other languages: [English](preprocessorder.md), [Russian/Русский](preprocessorder.ru.md). 

Backend of the customer application: preprocess order.

## Process description

- The [Delivery Service Application](../../../README.ru.md) includes a script that pre-processes the order before sending it to the kitchen for preparation.
- Executed automatically as part of the [makeorder](makeorder.ru.md) process.
- Backend services involved: [customerbackend](../../backend/customerbackend.ru.md) and [warehousebackend](../../backend/warehousebackend.ru.md).
- The database has tables [delivery_customer_recipe](../../dbtables/delivery_customer_recipe.md), [delivery_customer_ingredient](../../dbtables/delivery_customer_ingredient.md) and [delivery_customer_product](../../dbtables/delivery_customer_product.md), which contains recipes for each product indicating the required starting products and their quantity/weight/volume. Recipes are necessary so that on their basis it is possible to obtain the quantity of initial products required to complete the order.
     - Data from these tables comes from the database related to the [managerbackend](../../backend/managerbackend.ru.md) service using the replication mechanism
- The database has a table [delivery_wh_whproduct](../../dbtables/delivery_wh_whproduct.md), which stores data on products in the warehouse at the current time.

![placing_order_overall](../../img/placing_order_overall.png)

## Step-by-step execution

- The service receives a request including order parameters that were specified by the client (the order is represented as an object [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)).
- If the **quantity** in the warehouse is **not enough**, then the process [Deliver from store to warehouse](../courier/store2wh.md) is started asynchronously, and a response is sent to the service that called this process.
- If there is **enough quantity** in the warehouse, then the [Deliver from warehouse to kitchen](../warehouse/fromwhtokitchen.md) process is started asynchronously, and a response is sent to the service that called this process.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)
