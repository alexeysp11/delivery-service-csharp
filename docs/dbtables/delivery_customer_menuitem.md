# delivery_customer_menuitem Table 

Menu item.

## Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)

## Fields 

- **Menu item** - menu element, product (name: `delivery_menuitem_c`)
     - `delivery_menuitem_c_id: integer` - product ID,
     - `name: varchar` - name,
     - `price: double precision` - price,
     - `description: varchar` - description,
     - `delivery_category_c_id: integer` - category ID,
     - `picture: bytea` - image.
