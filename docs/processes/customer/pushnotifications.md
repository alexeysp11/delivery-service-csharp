# pushnotifications

Read this in other languages: [English](pushnotifications.md), [Russian/Русский](pushnotifications.ru.md). 

Backend of the customer application: receiving push notifications.

The push notification scenario in the delivery service app involves sending real-time notifications to users through SignalR. 

Related modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

- From the receiver POV, the app receives and displays the notification on their device, providing relevant information about their order status or other updates.
- From the sender POV, the app sends notifications to users based on their order status or other relevant updates, using SignalR to ensure that notifications are delivered in real-time.

## Step-by-step execution
