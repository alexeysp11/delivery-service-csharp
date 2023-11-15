# changeproductprice

[English](changeproductprice.md) | [Русский](changeproductprice.ru.md)

Name: **Change product prices**.

The scenario that is responsible for setting prices for products.
This scenario is used mostly by company managers.

For this scenario, it is necessary to complete the approval chain (for example, *marketer*, *financial analyst*, *CEO*).

Process pattern: [organizational](../../processpatterns/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.md) | [approval](../manager/approval.md) |
| [adminbackend](../../backend/adminbackend.md) | [dbreplication](../admin/dbreplication.md) |

## Process description

![organizational_overall](../../img/organizational_overall.png)

### Step-by-step execution

- Manager logs into the app and navigates to the "Product Pricing" section
- Manager selects the product whose price needs to be changed
- App provides options to enter a new price and reason for the change
- Manager submits the price change request
- App updates the product pricing database with the new price
- App notifies relevant staff members about the price change

![manager.changeproductprice](../../img/activitydiagrams/manager.changeproductprice.png)
