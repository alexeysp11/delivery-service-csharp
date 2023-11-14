# notificationscheduling

[English](notificationscheduling.md) | [Русский](notificationscheduling.ru.md)

Name: **Notifications scheduling**.

The scenario responsible for notification scheduling in the delivery service company involves determining when to send notifications to customers based on factors such as delivery times, order status, and customer preferences. 

Process pattern: [organizational](../../processpatterns/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Process description

![organizational_overall](../../img/organizational_overall.png)

## Data structures

### Objects 

- The delivery schedule model could include properties such as delivery times and routes. 
- The order status model could include properties such as order status and estimated delivery times. 
- The customer preference model could include properties such as notification preferences and contact information.
