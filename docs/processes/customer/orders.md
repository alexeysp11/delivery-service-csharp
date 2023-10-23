# customer.orders

Read this in other languages: [English](customer.orders.md), [Russian/Русский](customer.orders.ru.md). 

Customer client application: orders

The description of the **client application** is presented at [this link](../../frontend/customerclient.md).

## Process description

- Displaying information on previous orders in the form of lists:
    - list of all orders,
    - information on a specific order:
        - the actual time of registration, cooking and delivery;
        - Estimated time of preparation and delivery,
        - the total amount of the order,
        - list of order items (category, product name, image, cost),
        - place of delivery;
        - status.
- Statistics on previous orders in the form of dashboards:
    - by time:
        - day,
        - a week,
        - month,
        - year,
        - all the time;
    - according to the type of charts:
        - line chart,
        - barchart,
        - histogram,
        - Scatter plot, etc.;
    - metrics:
        - the total amount of the order,
        - position value,
        - the number of orders,
        - the number of positions,
        - time of placing orders,
        - place of delivery.
- Tracking the status of the order (manufacturing, delivery + distance of the courier in meters and / or minutes) - in the "Current orders" section.
- Use of predictive models: estimated cooking and delivery times.
- Uploading files to and from the server:
    - file extensions: images, PDF.
    - sending a message to e-mail/Telegram.
    - Try to make an HTML preview and then convert to PDF using [workflow-lib](https://github.com/alexeysp11/workflow-lib).

### Step-by-step execution

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

- The user opens the "All Orders" page.
- The user can open a specific order, get a preview and upload it as a file.
- From the list of all orders, you can go to the "Dashboards", set filters for uploading statistics, get a preview and upload it as a file.

## Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)

## Purchase order template 

![purchase-order-template](https://templates.invoicehome.com/purchase-order-template-us-mono-black-750px.png)
