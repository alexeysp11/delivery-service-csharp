# notifymanual

[English](notifymanual.md) | [Русский](notifymanual.ru.md)

Name: **Send notifications to users manually**.

The scenario responsible for notifying employees by manager in the delivery service company involves sending messages or alerts to employees through the management app or other communication channels to provide updates on schedules, tasks, or other important information.

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

Platform version: v0.1

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.md) | [sendnotifications](../notificationsbackend/sendnotifications.md) |

## Process description

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Step-by-step execution plan of the process

- Manager opens the app.
- Manager selects "Notify Employees" option.
- The system prompts the manager to provide details about the notification.
- The manager provides details about the notification.
- The system sends the notification to all employees.

![warehouse.reportincident](../../img/activitydiagrams/warehouse.reportincident.png)
