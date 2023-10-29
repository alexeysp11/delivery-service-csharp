# authbackend

Read this in other languages: [English](authbackend.md), [Russian/Русский](authbackend.ru.md). 

`authbackend` - backend service that is responsible for managing user login and authentication.

The authentication backend service used by client-side apps in the delivery service company is responsible for verifying user identities and granting access to specific features and functions based on their permissions. 
It uses industry-standard encryption and security protocols to ensure that user data is protected at all times.

### Overall description of the system

![system_overall](../img/system_overall.png)

### Description of the service 

- [workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.
- In order to simplify the system model, we will assume that all backend services use the same database. Therefore, information on the names of tables and their fields can be found in the description of the corresponding service (for example, such services include [customer backend](customerbackend.md ), [kitchen backend](kitchenbackend.md), [courier backend](courierbackend.md), [manager backend](managerbackend.md)).
<!--
- This service writes / reads session tokens to the database and through the message broker notifies services in which the availability of tokens is critical about changes in the database related to tokens
-->

## Integration with authentication service  

An example of integration of the **authentication service** [workflow-auth](https://github.com/alexeysp11/workflow-auth) with this application is shown in the figure below:

![authentication](../img/authentication.png)

### Sign up

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

### Sign in

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Sign up](../processes/customer/signup.md)
