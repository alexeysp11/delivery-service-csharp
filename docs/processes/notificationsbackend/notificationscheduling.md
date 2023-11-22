# notificationscheduling

[English](notificationscheduling.md) | [Русский](notificationscheduling.ru.md)

Name: **Notifications scheduling**.

The scenario responsible for notification scheduling in the delivery service company involves determining when to send notifications to customers based on factors such as delivery times, order status, and customer preferences. 

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

Platform version: v0.1

## Process description

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Step-by-step execution

- Defining the notification types and triggers
- Designing the notification scheduling system
- Implementing the scheduling logic and UI components
- Testing the scheduling functionality
- Integrating the scheduling system with other app features
- Monitoring and optimizing the notification scheduling performance

## Data structures

### Objects 

- The delivery schedule model could include properties such as delivery times and routes. 
- The order status model could include properties such as order status and estimated delivery times. 
- The customer preference model could include properties such as notification preferences and contact information.
