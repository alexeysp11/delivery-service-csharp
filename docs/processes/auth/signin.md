# signin

[English](signin.md) | [Русский](signin.ru.md)

Name: **Sign in**.

The sign in scenario in the customer client side app involves a user entering their login and password to access their account and place orders for delivery.

Responsible modules: [backend service](../../backend/authbackend.md).

Platform version: v0.1

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [workflow-auth](https://github.com/alexeysp11/workflow-auth) | |

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

## Data structures

### Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs)

### DTOs 

- [SignInModel](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SignInModel.cs)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCredentials.cs)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VUCResponse.cs)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SessionToken.cs)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/TokenRequest.cs)

### Database tables

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
