# delivery_category_cb Table 

*Used by*: [customerbackend](../../backend/customerbackend.md) 

*Defined in*: [initcustomer.sql](../../dbinit/initcustomer.sql)

Category.

## Objects

- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/ProductCategory.cs)

## Fields 

- **Category** - product category in the menu (name: `delivery_category_cc`):
     - `delivery_category_cc_id: integer` - category ID,
     - `name: varchar` - name,
     - `description: varchar` - description,
     - `picture: bytea` - image.
