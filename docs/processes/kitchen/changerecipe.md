# changerecipe

[English](changerecipe.md) | [Русский](changerecipe.ru.md)

Name: **Change recipe**.

The scenario for changing the composition and ingredients of dishes in the delivery service application, includes obtaining information about the current composition of dishes from the database, calculating and changing the necessary ingredients required for preparing dishes, and cooking instructions.
A necessary condition when changing the composition of dishes is to set the date and time when the changes will become relevant.

The scenario also includes a chain of approvals for changes (for example, *kitchen manager*, *marketing*, *financial analyst*, *CEO*).

If the approval is successful, the application updates the composition of the dishes and notifies the other microservices of the platform about the changes that have occurred.

Within the framework of this project, we proceed from the idea that all the ingredients necessary for preparing dishes can be easily purchased at a grocery store.
However, in the real world, it is possible that for some products, it will be necessary to change the supply chain, which in turn may impose restrictions on setting the date and time when changes to food formulations will be applied.

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [client application](../../frontend/kitchenclient.md), [backend service](../../backend/kitchenbackend.md)

Platform version: v0.1

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.md) | [approval](../manager/approval.md) |
| [adminbackend](../../backend/adminbackend.md) | [dbreplication](../admin/dbreplication.md) |

## Process description

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Step-by-step execution plan of the process

- Kitchen employee logs into the app and navigates to the "Recipe Management" section
- Employee selects the recipe to be modified
- App provides options to edit ingredients, quantities, cooking instructions, etc.
- Employee submits the changes
- App updates the recipe database with the modifications
- App notifies relevant staff members about the changes

![kitchen.changemenu](../../img/activitydiagrams/kitchen.changemenu.png)
