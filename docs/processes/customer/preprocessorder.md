# preprocessorder

[English](preprocessorder.md) | [Русский](preprocessorder.ru.md)

Name: **preprocess order**.

The preprocessing order scenario in the delivery service app involves retrieving recipes from the database, calculating the required and actual amount of ingredients, and asynchronously invoking processes for delivering ingredients to the kitchen or products from the store into the warehouse. 
Based on these calculations, the app determines the estimated delivery time for the order.

Macro process: [delivering](../../macroprocesses/delivering.md)

Responsible modules: [backend service](../../backend/customerbackend.md)

Depends on: 
- [customerbackend](../../backend/customerbackend.md)
    - [makeorder](../customer/makeorder.md)

Influences on:
- [warehousebackend](../../backend/warehousebackend.md)
    - [wh2kitchen](../warehouse/wh2kitchen.md)
    - [kitchen2wh](../warehouse/kitchen2wh.md)
- [kitchenbackend](../../backend/kitchenbackend.md)
    - [preparemeal](../kitchen/preparemeal.md)
- [courierbackend](../../backend/courierbackend.md)
    - [store2wh](../courier/store2wh.md)
    - [deliverorder](../courier/deliverorder.md)

## Process description

- The [Delivery Service Application](../../../README.ru.md) includes a script that pre-processes the order before sending it to the kitchen for preparation.
- Executed automatically as part of the [makeorder](../customer/makeorder.ru.md) process.
- Backend services involved: [customerbackend](../../backend/customerbackend.md), [warehousebackend](../../backend/warehousebackend.md), [kitchenbackend](../../backend/kitchenbackend.md), [courierbackend](../../backend/courierbackend.ru.md).
- The database has tables [delivery_recipe_cb](../../dbtables/customer/delivery_recipe_cb.md), [delivery_ingredient_cb](../../dbtables/customer/delivery_ingredient_cb.md) and [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md), which contains recipes for each product indicating the required starting products and their quantity/weight/volume. Recipes are necessary so that on their basis it is possible to obtain the quantity of initial products required to complete the order.
     - Data from these tables comes from the database related to the [managerbackend](../../backend/managerbackend.ru.md) service using the replication mechanism.
- The database has a table [delivery_whproduct_whb](../../dbtables/warehouse/customer/delivery_whproduct_whb.md), which stores data on products in the warehouse at the current time.

![delivering_overall](../../img/delivering_overall.png)

### Step-by-step execution

- The service receives a request including order parameters that were specified by the client (the order is represented as an object [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)).
- If the **quantity** in the warehouse is **not enough**, then the process [Deliver from store to warehouse](../courier/store2wh.md) is started asynchronously, and a response is sent to the service that called this process.
- If there is **enough quantity** in the warehouse, then the [Deliver from warehouse to kitchen](../warehouse/wh2kitchen.md) process is started asynchronously, and a response is sent to the service that called this process.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)

## Data

### Objects 

- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Ingredient.md)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [Recipe](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Recipe.md)
- [WHProduct](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/WHProduct.md)

### Database tables 

- [delivery_employee_whb](../../dbtables/warehouse/delivery_employee_whb.md)
- [delivery_useraccount_whb](../../dbtables/warehouse/delivery_useraccount_whb.md)
- [delivery_ingredient_cb](../../dbtables/customer/delivery_ingredient_cb.md)
- [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md)
- [delivery_recipe_cb](../../dbtables/customer/delivery_recipe_cb.md)
- [delivery_whproduct_whb](../../dbtables/warehouse/customer/delivery_whproduct_whb.md)
