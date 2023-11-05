# rateorder

[English](rateorder.md) | [Русский](rateorder.ru.md)

Name: **Rate order**.

The overall description of the scenario for rating and reviewing an order in the customer backend service is that it allows customers to provide feedback on the quality of their order, the delivery experience, and the overall service. 

The interactive steps within the scenario include selecting a star rating, writing a review, and submitting the feedback.

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md)

Infuences on: 
- [notificationsbackend](../../backend/notificationsbackend.md)
    - [sendnotifications](../notificationsbackend/sendnotifications.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- The delivery employee updates the order status and signals the completion of delivery (this is implemented within the [updatedeliverystatus](../courier/updatedeliverystatus.ru.md) process).
- The system sends a notification to the customer asking for a rating.
- Customer rates the order based on their experience.
- The system stores the rating in the database.
- The system updates the overall rating of the restaurant.
- If the rating is below a certain threshold, the system sends a notification to the restaurant manager.

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)

## Data

### Objects 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)
- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- The delivery order rate model
    - The delivery order rate model could have properties such as order ID, rating, comments, and timestamp. It could also have methods for submitting ratings, retrieving ratings for a specific order, and calculating average ratings. 
    - The difference between delivery order rate model and customer feedback model is that delivery order rate model specifically focuses on the delivery aspect of the service, while customer feedback model covers a broader range of aspects. These two models are related in that they both provide feedback on the service provided by the delivery service app.

### DTOs 

- OrderDTO 
- UserDTO
