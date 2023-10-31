# rateorder

[English](rateorder.md) | [Русский](rateorder.ru.md)

Customer client application: rate order.

The overall description of the scenario for rating and reviewing an order in the customer backend service is that it allows customers to provide feedback on the quality of their order, the delivery experience, and the overall service. 

The interactive steps within the scenario include selecting a star rating, writing a review, and submitting the feedback.

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

### Step-by-step execution

- Customer receives the order.
- The system sends a notification to the customer asking for a rating.
- Customer rates the order based on their experience.
- The system stores the rating in the database.
- The system updates the overall rating of the restaurant.
- If the rating is below a certain threshold, the system sends a notification to the restaurant manager.
