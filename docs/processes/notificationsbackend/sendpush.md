# sendpush

[English](sendpush.md) | [Русский](sendpush.ru.md)

Name: **Sending push notifications to users**.

A script responsible for notifying users using push notifications.

This scenario should not be confused with the [notifymanual](../notificationsbackend/notifymanual.ru.md) scenario, since [notifymanual](../notificationsbackend/notifymanual.ru.md) is responsible for manual notification by users within the company, while as [sendpush](../notificationsbackend/sendpush.ru.md) is used to automatically sendpush all users of the system (including customers and potential buyers).

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [backend service](../../backend/notificationsbackend.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution