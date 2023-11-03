# sendnotifications

[English](sendnotifications.md) | [Русский](sendnotifications.ru.md)

The scenario for sending notifications in the delivery service company.

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [backend service](../../backend/systembackend.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- User triggers an event that requires a notification to be sent (e.g., order confirmation, delivery update)
- System identifies the notification type and content based on the event
- System retrieves the user's notification preferences and contact information
- System composes the notification message and formats it according to the user's preferences and device capabilities
- System sends the notification message to the user's preferred channel (e.g., email, push notification, SMS)
- System tracks the notification delivery status and reports any errors or issues

![notificationsbackend.sendnotifications](../../img/activitydiagrams/notificationsbackend.sendnotifications.png)
