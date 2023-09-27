# customer backend 

Read this in other languages: [English](customerbackend.md), [Russian/Русский](customerbackend.ru.md). 

Backend of the customer application 

Overall description of the system: 

![system_overall](../img/system_overall.png)

The description of the client application is presented at [this link](../frontend/customerclient.md).
Understanding how the client application will be used allows you to form requirements for its main backend service.

Description of the application backend for consumers:
- Listens to the message queue, which writes messages about changes in users and tokens stored by the [authentication API](authbackend.md) module.
- Writes information about changes in users and tokens to the message queue (the queue listens to the [authentication API](authbackend.md) module).
- For requests from a client application, it checks the session token.
- Uploading information for order reports: a list of all orders, information on a specific order (actual time of registration, cooking and delivery; estimated time of cooking and delivery, total order amount, cost of order items, delivery place; status).
- Integration with payment services (according to the types of payment indicated earlier).
- User fields:
    - login,
    - email,
    - telephone,
    - password,
    - GUID of the user.
- Temporary user fields:
    - login,
    - email,
    - telephone,
    - password,
    - user GUID,
    - ID of the old entry to deactivate.
