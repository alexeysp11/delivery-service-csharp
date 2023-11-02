# supplierrelationships 

[English](supplierrelationships.md) | [Русский](supplierrelationships.ru.md)

Manager client application: managing supplier relationships.

The scenario responsible for managing supplier relationships by manager in the delivery service company involves maintaining a database of suppliers, negotiating contracts and pricing, tracking deliveries and quality of products or services, and communicating with suppliers as needed.

Macro process: [organizational](../../macroprocesses/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Process description

![organizational_overall](../../img/organizational_overall.png)

### Step-by-step execution

- The manager opens the delivery service app and navigates to the backend service for managers.
- The manager selects the option to manage supplier relationships.
- The app displays a list of current suppliers, along with their contact information and pricing details.
- The manager can view supplier performance metrics, such as on-time delivery rates and product quality ratings.
- The manager can add new suppliers or remove existing ones as needed.
- The manager can negotiate prices and terms with suppliers through the app.

## Data 

### Objects

- Supplier
    - Supplier object could have properties like name, contact information, product offerings, etc. 
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- DeliveryService
    - DeliveryService object could have properties like name, contact information, delivery area, etc. 

### DTOs

- SupplierRelationshipDTO
    - SupplierRelationshipDTO could have properties like supplierName, deliveryServiceName, relationshipType, managerName, managerID, etc.
