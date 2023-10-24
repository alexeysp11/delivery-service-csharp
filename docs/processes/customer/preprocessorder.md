# customerbackend.preprocessorder

Read this in other languages: [English](preprocessorder.md), [Russian/Русский](preprocessorder.ru.md). 

Backend of the customer application: preprocess order.

## Process description

- Executed automatically.
- The service receives a request from the client order parameters sent by the customer.
- The database contains a recipe for each product indicating the required starting products and their quantity/weight/volume.
- Recipes are unloaded from the database to get the quantity of initial products needed to fulfill the order.
- A request is made to the database to obtain the actual quantity of the required initial products in the warehouse.
- If the **quantity** in the warehouse is **not enough**, then the process [Deliver from store to warehouse](../courier/store2wh.md) is started asynchronously, and a response is sent to the service that called this process.
- If there is **enough quantity** in the warehouse, then the [Deliver from warehouse to kitchen](../warehouse/fromwhtokitchen.md) process is started asynchronously, and a response is sent to the service that called this process.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)
