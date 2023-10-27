# customer.signup

Read this in other languages: [English](signup.md), [Russian/Русский](signup.ru.md). 

Customer client application: sign up.

Related modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution

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
