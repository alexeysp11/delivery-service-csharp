# customer.signin

Read this in other languages: [English](customer.signin.md), [Russian/Русский](customer.signin.ru.md). 

Customer client application: sign in.

The description of the **client application** is presented at [this link](../customerclient.md).

## Process description

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../../img/authentication.png)

### Step-by-step execution

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Objects 

- [SignInModel](../../classes/models/Authentication/SignInModel.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VUCResponse.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/TokenRequest.md)
