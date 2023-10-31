# kitchenbackend

[English](kitchenbackend.md) | [Русский](kitchenbackend.ru.md)

`kitchenbackend` is a backend service that manages the preparation of food orders. 

The backend service for the kitchen in the delivery service app is responsible for managing orders and facilitating communication between the kitchen staff, warehouse staff and couriers. 

It allows kitchen staff to receive and manage orders, update order status, receive real-time updates on product availability, and communicate with couriers about delivery details. 
The service also provides real-time analytics and reporting to help optimize kitchen operations and improve delivery efficiency.

[Client app](../frontend/kitchenclient.md)

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Order preparation](../processes/kitchen/preparemeal.md)
- [Order equipment](../processes/kitchen/requestequipment.md)
- [Receive notifications about delivery of ingredients](../processes/kitchen/notificationsaboutingredients.md)
- [Deliver from warehouse to kitchen](../processes/warehouse/wh2kitchen.md)
