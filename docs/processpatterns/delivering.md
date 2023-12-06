# delivering

[English](delivering.md) | [Русский](delivering.ru.md)

Name: **Delivering**.

`delivering` is a pattern for implementing business processes that are associated with creating a delivery order, as well as payment and delivery of the order.

![delivering_overall](../img/processpatterns/delivering_overall.png)

This diagram shows the life cycle of a product or food delivery order:

![productlifecycle](../img/productlifecycle.png)

### Flowcharts for network communication

![overall.delivering](../img/flowcharts/overall.delivering.png)

## Objects/DTOs

When processing an order (order registration, payment, preparation, delivery), the following objects/DTOs are used:
- [InitialOrder](../../models/Orders/InitialOrder.cs)/InitialOrderDTO: model for placing an order
- DeliveryOrder/DeliveryOrderDTO: model for invoicing control
- [DeliveryWh2Kitchen](../../models/Orders/DeliveryWh2Kitchen.cs) (inherited from DeliveryOperation): model for transferring products from warehouse to kitchen (shipping point, destination, start time, end time, products, ingredients)
- DeliveryOrder/DeliveryOrderDTO: model for delivering products from a store to a warehouse
- [CookingOperation](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/CookingOperation.cs): model for preparing an order (start time, end time, products, ingredients, recipes)
- [DeliveryKitchen2Wh](../../models/Orders/DeliveryKitchen2Wh.cs) (inherited from DeliveryOperation): model for transferring a finished order from the kitchen to the warehouse (shipping point, destination, start time, end time, products, order number, generated order QR code)
- [DeliveryOperation](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Delivery/DeliveryOperation.cs)/DeliveryOperationDTO: model for delivery (QR code on the order, QR code on the backpack, departure point, destination, start time, end time, order number)
