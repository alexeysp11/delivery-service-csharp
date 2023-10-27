# customer.signin

Read this in other languages: [English](signin.md), [Russian/Русский](signin.ru.md). 

Customer client application: sign in.

Related modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution

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
