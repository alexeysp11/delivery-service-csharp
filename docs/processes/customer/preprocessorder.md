# customerbackend.preprocessorder

Read this in other languages: [English](customerbackend.preprocessorder.md), [Russian/Русский](customerbackend.preprocessorder.ru.md). 

Backend of the customer application: preprocess order

## Process description

- Executed automatically.
- The service receives a request from the client order parameters sent by the customer.
- The database contains a recipe for each product indicating the required starting products and their quantity/weight/volume.
- Recipes are unloaded from the database to get the quantity of initial products needed to fulfill the order.
- A request is made to the database to obtain the actual quantity of the required initial products in the warehouse.
- If the quantity in the warehouse is not enough, then the process "Deliver from store to warehouse" is started.
- If there is enough quantity in the warehouse, then the "Deliver from warehouse to kitchen" process is started.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)
