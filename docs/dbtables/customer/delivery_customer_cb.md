# delivery_customer_cb Table 

*Used by*: [customerbackend](../../backend/customerbackend.md) 

*Defined in*: [initcustomer.sql](../../dbinit/initcustomer.sql)

Customer.

## Objects

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)

## Fields 

- **Customer** - Customer (name: `delivery_customer_cc`):
     - `delivery_customer_cc_id: integer` - customer ID,
     - `customer_uid: varchar` - GUID of the customer,
     - `login: varchar` - login,
     - `email: varchar` - email,
     - `phone_number: varchar` - phone,
     - `password: varchar` - hashed password.
