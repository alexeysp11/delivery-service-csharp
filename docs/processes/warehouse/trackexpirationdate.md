# trackexpirationdate

Read this in other languages: [English](trackexpirationdate.md), [Russian/Русский](trackexpirationdate.ru.md). 

Warehouse client application: track expiration date.

The scenario responsible for tracking expiration dates of the products stored in the warehouse by warehouse employees in the delivery service company involves using inventory management software to track the date of receipt and expiration for each product. 
This allows warehouse employees to ensure that products are used or sold before they expire and to remove expired products from inventory in a timely manner.

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md).

## Process description

### Step-by-step execution

- Warehouse employee opens the app.
- The employee selects the product they want to track.
- The system checks the inventory database for that product.
- The system displays the expiration date of the product to the employee.
- If the product is expired, the system sends a notification to the restaurant manager to dispose of it.
