# adminclient

Read this in other languages: [English](adminclient.md), [Russian/Русский](adminclient.ru.md). 

`adminclient` is a client-side application that is used by administrators to manage users, products, and orders across the platform.

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Authentiacation 

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

![authentication](../img/authentication.png)

### Sign in

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
