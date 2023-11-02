# notificationsbackend

[English](notificationsbackend.md) | [Русский](notificationsbackend.ru.md)

`notificationsbackend` is a backend service that handles comminication with customers regarding their orders via push notifications and email.

The backend service responsible for sending push notifications in the delivery service app is a push notification service. Its possible functionalities include:

- User registration and device management
- Notification composition and sending
- Notification scheduling and targeting
- Notification tracking and reporting
- Notification personalization and localization

The backend service responsible for sending email messages in the delivery service app is an email service. Its possible functionalities include:

- Composing and sending emails
- Receiving and processing incoming emails
- Email formatting and styling
- Email attachments and links
- Email templates and automation

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sending notifications](../processes/systembackend/sendnotifications.md)
- [Notify](../processes/notificationsbackend/notify.md)
- [Notification scheduling](../processes/notificationsbackend/notificationscheduling.md)
- [Notification targeting](../processes/notificationsbackend/notificationtargeting.md)
- [Sending email](../processes/notificationsbackend/sendemail.md)
