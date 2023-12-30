# delivering

[English](README.md) | [Русский](README.ru.md)

Name: **Delivering**.

`delivering` is a pattern for implementing business processes that are associated with creating a delivery order, as well as payment and delivery of the order.

![delivering_overall](../../img/flowchartnames/delivering_overall.png)

This diagram shows the life cycle of a product or food delivery order:

![productlifecycle](../../img/productlifecycle.png)

### Flowcharts for network communication

- [makeorder](makeorder.md)
- [makepayment](makepayment.md)
- [confirmstore2wh](confirmstore2wh.md)
- [store2wh](store2wh.md)
- [requeststore2wh](requeststore2wh.md)
- [wh2kitchen](wh2kitchen.md)
- [preparemeal](preparemeal.md)
- [kitchen2wh](kitchen2wh.md)
- [scanqronorder](scanqronorder.md)
- [scanbackpack](scanbackpack.md)
- [deliverorder](deliverorder.md)

![overall.delivering](../../img/flowcharts/overall.delivering.png)

## Data structures

When processing an order (order registration, payment, preparation, delivery), the following objects/DTOs are used:

| Object | DTO | Notes |
| --- | ---- | --- |
| [InitialOrder](../../../src/models/Orders/InitialOrder.cs) | InitialOrderDTO | model for placing an order |
| [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs) | DeliveryOrderDTO  | model for invoicing control, or delivering products from a store to a warehouse | 
| [DeliveryWh2Kitchen](../../../src/models/Orders/DeliveryWh2Kitchen.cs) | DeliveryWh2KitchenDTO | model for transferring products from warehouse to kitchen (shipping point, destination, start time, end time, products, ingredients) |
| [CookingOperation](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/CookingOperation.cs) | CookingOperationDTO | model for preparing an order (start time, end time, products, ingredients, recipes) |
| [DeliveryKitchen2Wh](../../models/Orders/DeliveryKitchen2Wh.cs) | DeliveryKitchen2WhDTO | model for transferring a finished order from the kitchen to the warehouse (shipping point, destination, start time, end time, products, order number, generated order QR code) |
| [DeliveryOperation](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Delivery/DeliveryOperation.cs) | DeliveryOperationDTO  | model for delivery (QR code on the order, QR code on the backpack, departure point, destination, start time, end time, order number) |
