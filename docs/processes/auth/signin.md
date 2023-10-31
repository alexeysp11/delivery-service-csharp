# signin

[English](signin.md) | [Русский](signin.ru.md)

Client application: sign in.

The sign in scenario in the customer client side app involves a user entering their login and password to access their account and place orders for delivery.

Responsible modules: [backend service](../../backend/authbackend.md).

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution

- User opens the customer client side app
- User clicks on the "Sign In" button
- User enters their login and password
- App validates the user's credentials
- If the credentials are valid, the app grants the user access to their account and displays their order history and other relevant information
- If the credentials are invalid, the app displays an error message and prompts the user to try again or reset their password

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Data

### Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

### DTOs 

- [SignInModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignInModel.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VUCResponse.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/TokenRequest.md)

### Database tables

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
