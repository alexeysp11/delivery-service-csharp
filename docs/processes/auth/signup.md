# signup

Read this in other languages: [English](signup.md), [Russian/Русский](signup.ru.md). 

Client application: sign up.

The sign up scenario in the customer client side app involves a user creating a new account by providing their personal information, such as login, email address, and password.

Related modules: [backend service](../../backend/authbackend.md).

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution

- User opens the customer client side app
- User clicks on the "Sign Up" button
- User enters their personal information, such as name, email address, and password
- App validates the user's information and checks if the email address is already registered
- If the information is valid and the email address is not already registered, the app creates a new account for the user and grants them access to the app's features and functionality
- If there are any errors or issues with the user's information, the app displays an error message and prompts the user to correct their information before proceeding.

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Data

### Objects 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

### DTOs 

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignUpModel.md)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCreationResult.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSURequest.md)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSUResponse.md)

### Database tables

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
