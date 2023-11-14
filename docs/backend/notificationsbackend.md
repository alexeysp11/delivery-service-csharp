# notificationsbackend

[English](notificationsbackend.md) | [Русский](notificationsbackend.ru.md)

`notificationsbackend` is a backend service that handles comminication with customers regarding their orders via push notifications and email.

The backend service responsible for sending push notifications and email messages in the delivery service app. Its possible functionalities include:

- Push notifications:
    - User registration and device management
    - Notification composition and sending
    - Notification scheduling and targeting
    - Notification tracking and reporting
    - Notification personalization and localization
- Email messages:
    - Composing and sending emails
    - Receiving and processing incoming emails
    - Email formatting and styling
    - Email attachments and links
    - Email templates and automation

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sending notifications](../processes/notificationsbackend/sendnotifications.md)
- [Notify](../processes/notificationsbackend/sendpush.md)
- [Notification scheduling](../processes/notificationsbackend/notificationscheduling.md)
- [Notification targeting](../processes/notificationsbackend/notificationtargeting.md)
- [Sending email](../processes/notificationsbackend/sendemail.md)
- [Receiving notifications](../processes/notificationsbackend/getnotified.md)
