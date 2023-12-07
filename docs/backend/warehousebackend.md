# warehousebackend 

[English](warehousebackend.md) | [Русский](warehousebackend.ru.md)

`warehousebackend` is a backend service that handles inventory management and order fulfillment.

The warehouse backend service for delivery service app allows warehouse staff to sign in to their account, calculate product quantities, manage the inventory of products needed for food preparation, manage deliveries from the warehouse to the kitchen, receive notifications about changes in product quantity, and report incidents that occur in the warehouse.

Other possible functionalities of the service include generating inventory reports, and tracking product expiration dates.

[Client app](../frontend/warehouseclient.md)

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Calculate products](../processes/warehouse/calculateproducts.md)
- [Tracking expiration dates of products](../processes/warehouse/trackexpirationdate.md)
- [Notify about changes in product quantity](../processes/warehouse/notifyproductqtychanges.md)
- [Notify about an incident](../processes/systembackend/reportincident.md)
- [Generate invetory report](../processes/warehouse/inventoryreport.md)

## Flowchart steps

- [From WH to kitchen](../flowchartsteps/delivering/wh2kitchen.md)
- [From kitchen to warehouse](../flowchartsteps/delivering/kitchen2wh.md)
- [Deliver from store to warehouse](../flowchartsteps/delivering/store2wh.md)
