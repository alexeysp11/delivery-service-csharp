# customer.pendingorders

Read this in other languages: [English](orders.md), [Russian/Русский](orders.ru.md). 

Customer client application: pending orders.

Related modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

This process almost completely repeats [viewing all orders](orders.md), except that orders are filtered by status to be displayed on this form: it is necessary that it be "Processing", "In the process of cooking", " In delivery."

## Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)
