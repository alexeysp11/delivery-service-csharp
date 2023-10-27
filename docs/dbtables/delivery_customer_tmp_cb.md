# delivery_customer_tmp_cb Table 

Temporary customer.

Defined in the [initcustomer.sql](../../dbinit/initcustomer.sql) file.

## Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)

## Tables 

- [delivery_customer_cb](delivery_customer_cb.md)

## Fields 

    - `delivery_customer_tmp_cb_id: integer` - ИД потребителя,
    - `customer_uid: varchar` - GUID потребителя,
    - `login: varchar` - логин,
    - `email: varchar` - email,
    - `phone_number: varchar` - телефон,
    - `password: varchar` - хэшированный пароль.
