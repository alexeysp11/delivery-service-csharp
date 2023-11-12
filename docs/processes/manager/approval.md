# approval

[English](approval.md) | [Русский](approval.ru.md)

Name: **Approval**.

A scenario responsible for ensuring atomic action in the approval chain on the part of the selected manager.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md)

## Process description

Among other things, the following are passed into this process as input parameters:
- Requester and approver (links to account),
- Information on the process that needs to be agreed upon,
- Comment from the requester,
- A link to the process where the approval result will need to be redirected.

![maintenance_overall](../../img/maintenance_overall.png)
