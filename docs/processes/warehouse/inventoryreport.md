# inventoryreport

[English](inventoryreport.md) | [Русский](inventoryreport.ru.md)

Name: **Inventory report**.

The scenario responsible for getting inventory report by warehouse employees involves generating a report that displays current inventory levels, incoming shipments, outgoing orders, and other relevant information. 
This report could be generated on demand or scheduled to run at regular intervals.

Process pattern: [information](../../processpatterns/information.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md)

Platform version: v0.1

## Process description

![information_overall](../../img/processpatterns/information_overall.png)

### Step-by-step execution

- Warehouse employee opens the app.
- Employee selects "Inventory Report" option.
- The system retrieves the inventory data from the database.
- The system displays the inventory report to the employee.

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Data structures

| Object | DTO | Database table |
| --- | ---- | --- |
| InventoryReport | InventoryReportDTO | - |
| [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs) | - | - |
| [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs) | - | - |

- InventoryReport object could have properties like reportDate, inventoryLevel, product details, etc. 
- InventoryReportDTO could have properties like reportDate, inventoryLevel, productName, productDescription, productPrice, etc.
