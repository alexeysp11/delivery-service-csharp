# customerclient

[English](customerclient.md) | [Русский](customerclient.ru.md)

`customerclient` is a client-side application that is used by customers to browse products, place orders, and track deliveries.

[Backend service](../backend/customerbackend.md)

## Overall description of the system

![system_overall](../img/system_overall.png)

## Description of the application

- Directly communicates with the following backend services:
    - [authentication API](../backend/authbackend.md), 
    - [customer backend](../backend/customerbackend.md), 
    - [file service](../backend/fileservice.md), 
    - [statistical backend](../backend/statisticalbackend.md), 
    - [predictive backend](../backend/predictivebackend.md), 
    - [notifications](../backend/notificationsbackend.md).
- Payment types:
    - cash on delivery, 
    - using POS when receiving,
    - via bank's app using QR code,
    - in this application using CVC.

## Processes

- [Sign in](../processes/auth/signin.md)
- [Sign up](../processes/customer/signup.md)
- [User account](../processes/systembackend/useraccount.md)
- [Placing order](../processes/customer/makeorder.md)
- [Make a payment](../processes/customer/makepayment.md)
- [All orders](../processes/customer/orders.md): displayig information and statistical data about previous orders (in a form of lists and dashboards)
- [Pending orders](../processes/customer/pendingorders.md): order status tracking
- [Settings](../processes/customer/settings.md)
- [Cancel order](../processes/customer/cancelorder.md)
- [Receiving notifications](../processes/notificationsbackend/getnotified.md)
- [Watching videos](../processes/fileservice/watchingvideos.md)
