# delivery_customer_cb Table 

Customer.

Defined in the [initcustomer.sql](../../dbinit/initcustomer.sql) file.

## Objects

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)

## Fields 

- **Customer** - Customer (name: `delivery_customer_cc`):
     - `delivery_customer_cc_id: integer` - consumer ID,
     - `customer_uid: varchar` - GUID of the consumer,
     - `login: varchar` - login,
     - `email: varchar` - email,
     - `phone_number: varchar` - phone,
     - `password: varchar` - hashed password.
