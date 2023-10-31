# warehousebackend 

[English](warehousebackend.md) | [Русский](warehousebackend.ru.md)

`warehousebackend` is a backend service that handles inventory management and order fulfillment.

The warehouse backend service for delivery service app allows warehouse staff to sign in to their account, calculate product quantities, manage the inventory of products needed for food preparation, manage deliveries from the warehouse to the kitchen, receive notifications about changes in product quantity, and report incidents that occur in the warehouse.

Other possible functionalities of the service include generating inventory reports, and tracking product expiration dates.

The description of the **client application** is presented at [this link](../frontend/warehouseclient.md).

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Calculate products](../processes/warehouse/calculateproducts.md)
- [Tracking expiration dates of products](../processes/warehouse/trackexpirationdate.md)
- [From WH to kitchen](../processes/warehouse/fromwhtokitchen.md)
- [From kitchen to warehouse](../processes/warehouse/fromkitchentowh.md)
- [Deliver from store to warehouse](../processes/courier/store2wh.md)
- [Notify about changes in product quantity](../processes/warehouse/notifyproductqtychanges.md)
- [Notify about an incident](../processes/warehouse/reportincident.md)
- [Generate invetory report](../processes/warehouse/inventoryreport.md)
