# delivery_customer_token_cb Table

Customer token.

Defined in the [initcustomer.sql](../../dbinit/initcustomer.sql) file.

## Objects 

- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)

## Fields 

- **Customer token** - consumer session token (name: `delivery_customer_token_cb`):
     - `delivery_customer_token_cb_id: integer` - consumer token ID,
     - `token_guid: varchar` - generated token GUID,
     - `token_begin_dt: timestamp` - the beginning of the token,
     - `token_end_dt: timestamp` - end of token validity,
     - `customer_id: integer` - consumer ID.
