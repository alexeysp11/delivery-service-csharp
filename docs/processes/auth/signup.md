# signup

[English](signup.md) | [Русский](signup.ru.md)

Name: **Sign up**.

The sign up scenario in the customer client side app involves a user creating a new account by providing their personal information, such as login, email address, and password.

Responsible modules: [backend service](../../backend/authbackend.md).

Platform version: v0.1

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution plan of the process

- User opens the customer client side app
- User clicks on the "Sign Up" button
- User enters their personal information, such as name, email address, and password
- App validates the user's information and checks if the email address is already registered
- If the information is valid and the email address is not already registered, the app creates a new account for the user and grants them access to the app's features and functionality
- If there are any errors or issues with the user's information, the app displays an error message and prompts the user to correct their information before proceeding.

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Data structures

### Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs)

### DTOs 

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SignUpModel.cs)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCreationResult.cs)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCredentials.cs)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VSURequest.cs)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VSUResponse.cs)

### Database tables

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
