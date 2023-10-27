# delivery_menuitem_cb Table 

Menu item.

Defined in the [initcustomer.sql](../../dbinit/initcustomer.sql) file.

## Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)

## Fields 

- **Menu item** - menu element, product (name: `delivery_menuitem_cc`)
     - `delivery_menuitem_cc_id: integer` - product ID,
     - `name: varchar` - name,
     - `price: double precision` - price,
     - `description: varchar` - description,
     - `delivery_category_cc_id: integer` - category ID,
     - `picture: bytea` - image.
