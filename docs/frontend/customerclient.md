# customerclient

Read this in other languages: [English](customerclient.md), [Russian/Русский](customerclient.ru.md). 

`customerclient` is a customer client application.

## Requirements and description of the system

### Overall description of the system

![system_overall](../img/system_overall.png)

### Description of the customer application

- Directly communicates with [authentication API](../backend/authbackend.md), [customer backend](../backend/customerbackend.md), [file service](../backend/fileservice.md), [statistical model](../backend/statisticalmodel.md), [predictive model](../backend/predictivemodel.md), [email sender](../backend/emailsender.md), [push notifications](../backend/pushnotifications.md).
- Processes:
    - User's account.
    - [Making order](processes/customer.makeorder.md).
    - [All orders](processes/customer.orders.md): displayig information and statistical data about previous orders (in a form of lists and dashboards).
    - [Pending orders](processes/customer.pendingorders.md): order status tracking.
    - [Settings](processes/customer.settings.md).
    - Notifications.
    - Watching videos.
- Payment types:
    - cash on delivery, 
    - using POS when receiving,
    - via bank's app using QR code,
    - in this application using CVC.

A description of the backend service for this application is presented at [this link](../backend/customerbackend.md).

## Authentiacation 

[workflow-auth](https://github.com/alexeysp11/workflow-auth) is used as an external **authentication service**.

### Sign up

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

### Sign in

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
