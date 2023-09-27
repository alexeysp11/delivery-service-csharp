# authbackend

Read this in other languages: [English](authbackend.md), [Russian/Русский](authbackend.ru.md). 

`authbackend` - backend for authentication service 

## Service requirements and description

Overall description of the system: 

![system_overall](../img/system_overall.png)

Description of API for authentication:
- This service writes / reads session tokens to the database and through the message broker notifies services in which the availability of tokens is critical about changes in the database related to tokens (for example, such services include [customer backend](customerbackend.md ), [kitchen backend](kitchenbackend.md), [courier backend](courierbackend.md), [manager backend](managerbackend.md)).
- This service can be accessed by all client applications shown in the figure above in the "End user applications" section: [customer](../frontend/customerclient.md), [kitchen](../frontend/kitchenclient.md), [courier](../frontend/courierclient.md), [manager](../frontend/managerclient.md), [admin](../frontend/adminclient.md).
- [workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an authentication service.
