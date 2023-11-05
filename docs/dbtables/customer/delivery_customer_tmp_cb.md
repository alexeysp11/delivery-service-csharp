# delivery_customer_tmp_cb Table 

*Used by*: [customerbackend](../../backend/customerbackend.md) 

*Defined in*: [initcustomer.sql](../../dbinit/initcustomer.sql)

Temporary customer.

## Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)

## Tables 

- [delivery_customer_cb](delivery_customer_cb.md)

## Fields 

    - `delivery_customer_tmp_cb_id: integer` - ИД потребителя,
    - `customer_uid: varchar` - GUID потребителя,
    - `login: varchar` - логин,
    - `email: varchar` - email,
    - `phone_number: varchar` - телефон,
    - `password: varchar` - хэшированный пароль.
