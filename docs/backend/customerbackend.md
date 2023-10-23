# customerbackend

Read this in other languages: [English](customerbackend.md), [Russian/Русский](customerbackend.ru.md). 

`customerbackend` is a backend service that handles customer-related functions such as browsing products, placing orders, and managing account information.

## System requirements and description

### Overall description of the system

![system_overall](../img/system_overall.png)

The description of the **client application** is presented at [this link](../../frontend/frontend/customerclient.md).
Understanding how the client application will be used allows you to form requirements for its main backend service.

### Description of the application backend for consumers

- For requests from a client application, it checks the session token.
- Uploading information for order reports: a list of all orders, information on a specific order (actual time of registration, cooking and delivery; estimated time of cooking and delivery, total order amount, cost of order items, delivery place; status).
- Integration with payment services (according to the types of payment indicated earlier).
<!-- 
- Listens to the message queue, which writes messages about changes in users and tokens stored by the [authentication API](authbackend.md) module.
- Writes information about changes in users and tokens to the message queue (the queue listens to the [authentication API](authbackend.md) module). 
-->

## Table in the database

- **Customer** - consumer (name: `delivery_customer_c`):
     - `delivery_customer_c_id: integer` - consumer ID,
     - `customer_uid: varchar` - GUID of the consumer,
     - `login: varchar` - login,
     - `email: varchar` - email,
     - `phone_number: varchar` - phone,
     - `password: varchar` - hashed password.
- **Customer token** - consumer session token (name: `delivery_customer_token_c`):
     - `delivery_customer_token_c_id: integer` - consumer token ID,
     - `token_guid: varchar` - generated token GUID,
     - `token_begin_dt: timestamp` - the beginning of the token,
     - `token_end_dt: timestamp` - end of token validity,
     - `customer_id: integer` - consumer ID.
- **Category** - product category in the menu (name: `delivery_category_c`):
     - `delivery_category_c_id: integer` - category ID,
     - `name: varchar` - name,
     - `description: varchar` - description,
     - `picture: bytea` - image.
- **Menu item** - menu element, product (name: `delivery_menuitem_c`)
     - `delivery_menuitem_c_id: integer` - product ID,
     - `name: varchar` - name,
     - `price: double precision` - price,
     - `description: varchar` - description,
     - `delivery_category_c_id: integer` - category ID,
     - `picture: bytea` - image.
