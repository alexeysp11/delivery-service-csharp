# approval

[English](approval.md) | [Русский](approval.ru.md)

Name: **Approval**.

A scenario responsible for ensuring atomic action in the approval chain on the part of the selected manager.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md)

## Dependencies

### Depends on

| Backend service | Process |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.md) | [changeproductprice](../manager/changeproductprice.md) |

### Influences on

| Backend service | Process |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.md) | [sendnotifications](../notificationsbackend/sendnotifications.md) |

## Process description

Among other things, the following are passed into this process as input parameters:
- Requester and approver (links to account),
- Information on the process that needs to be agreed upon,
- Comment from the requester,
- A link to the process where the approval result will need to be redirected,
- A list of employees that should be notified about the approval result,
- A parameter that shows in what case it is necessary to notify about the decision (in all cases, only in case of refusal, only in case of approval, in no cases).

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- The request goes to the backend service, which provides the work of a specialist who must carry out the approval.
- The specialist is notified using [notificationsbackend](../../backend/notificationsbackend.ru.md).
- The request is sent to the client application, where it is saved in the database.
- The employee enters the application and approves or does not approve the request.
- The approval results are saved on the client application and on the backend service.
- If necessary, employees who are on the notification list are notified.

![manager.approval](../../img/activitydiagrams/manager.approval.png)

## Data structures

The list of objects (data models) for the chain of approval process may include candidate profiles, job descriptions, interview feedback, onboarding checklists, and other relevant data structures necessary for managing HR processes within the delivery service app.
