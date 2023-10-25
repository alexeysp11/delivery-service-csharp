# customerbackend

Read this in other languages: [English](customerbackend.md), [Russian/Русский](customerbackend.ru.md). 

`customerbackend` is a backend service that handles customer-related functions such as browsing products, placing orders, and managing account information.

The description of the **client application** is presented at [this link](../../frontend/frontend/customerclient.md).
Understanding how the client application will be used allows you to form requirements for its main backend service.

## Overall description of the system

![system_overall](../img/system_overall.png)

## Description of the application

- For requests from a client application, it checks the session token.
- Uploading information for order reports: a list of all orders, information on a specific order (actual time of registration, cooking and delivery; estimated time of cooking and delivery, total order amount, cost of order items, delivery place; status).
- Integration with payment services (according to the types of payment indicated earlier).
<!-- 
- Listens to the message queue, which writes messages about changes in users and tokens stored by the [authentication API](authbackend.md) module.
- Writes information about changes in users and tokens to the message queue (the queue listens to the [authentication API](authbackend.md) module). 
-->

## Processes

- [Sign in](../processes/customer/signin.md)
- [Sign up](../processes/customer/signup.md)
- [Placing order](../processes/customer/makeorder.md)
- [Make a payment](../processes/customer/makepayment.md)
- [All orders](../processes/customer/orders.md): displayig information and statistical data about previous orders (in a form of lists and dashboards)
- [Pending orders](../processes/customer/pendingorders.md): order status tracking
- [Cancel order](../processes/customer/cancelorder.md)
- Receiving notifications

## Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)

## Table in the database

- [delivery_customer](../dbtables/delivery_customer.md)
- [delivery_customer_tmp](../dbtables/delivery_customer_tmp.md)
- [delivery_customer_token](../dbtables/delivery_customer_token.md)
- [delivery_customer_category](../dbtables/delivery_customer_category.md)
- [delivery_customer_menuitem](../dbtables/delivery_customer_menuitem.md)
