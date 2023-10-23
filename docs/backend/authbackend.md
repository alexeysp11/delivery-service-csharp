# authbackend

Read this in other languages: [English](authbackend.md), [Russian/Русский](authbackend.ru.md). 

`authbackend` - backend service that is responsible for managing user login and authentication.

## Service requirements and description

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
