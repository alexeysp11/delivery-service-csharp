# getnotified

[English](getnotified.md) | [Русский](getnotified.ru.md)

Backend of the customer application: receiving push notifications.

The push notification scenario in the delivery service app involves sending real-time notifications to users through SignalR. 

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md)

## Process description

- From the receiver POV, the app receives and displays the notification on their device, providing relevant information about their order status or other updates.
- From the sender POV, the app sends notifications to users based on their order status or other relevant updates, using SignalR to ensure that notifications are delivered in real-time.

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- Getting push notifications from receiver POV:
    - Receiver opens the app.
    - The app establishes a connection with the SignalR server.
    - The server sends push notifications to the app.
    - The app displays the notifications to the user.
- Getting push notifications from sender POV:
    - Sender opens the app.
    - The app establishes a connection with the SignalR server.
    - The sender sends a push notification to the server.
    - The server sends the notification to the receivers who are subscribed to that event.

The step-by-step execution of the process is identical to the [rateorder](../customer/rateorder.md) process (except that the consumer does not rate the order, but simply reads the notification):

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)

## Data

### Objects 

- [Notification](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Notification.md)
- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)

### DTOs

- NotificationDTO
- CustomerDTO
