# delivery-service-csharp 

[English](README.md) | [Русский](README.ru.md)

A **delivery service app** is an ERP platform that enables users to order and receive goods. 
The app includes features such as browsing products, selecting delivery options, tracking orders in real-time, and making payments.

## Overall description 

### Goal 

The goals of the delivery service app in general are to provide a convenient and efficient way for customers to order and receive deliveries, while also streamlining the process for businesses and couriers involved in the delivery process.

The goals of the project are to develop a comprehensive delivery service app that meets the needs of all stakeholders involved in the delivery process, including customers, businesses, couriers, and managers. 
This includes developing client side apps for each user type, as well as backend services to support authentication, files, statistics, prediction, email sending, and push notifications.

### Scope 

The scope of the project includes developing a full-stack delivery service app that can handle all aspects of the delivery process, from customer orders to courier deliveries. 
This includes developing client side apps for six different user types, as well as backend services to support authentication, files, statistics, prediction, email sending, and push notifications.

### Who can use this app 

The application is designed to be used by customers, businesses, couriers, and managers involved in the delivery process. 
Any company that offers delivery services could potentially use this application, including restaurants, grocery stores, retail stores, and other businesses that offer delivery services.

## System requirements and description

### System description

- Types of client applications by end user type: 
    - [customers](docs/frontend/customerclient.md), 
    - [kitchen](docs/frontend/kitchenclient.md), 
    - [warehouse](docs/frontend/warehouseclient..md), 
    - [couriers](docs/frontend/courierclient.md), 
    - [managers](docs/frontend/managerclient.md), 
    - [HR](docs/frontend/hrclient.md), 
    - [financial managers](docs/frontend/financialclient.md), 
    - [marketing](docs/frontend/marketingclient.md), 
    - [admins](docs/frontend/adminclient.md), 
    - [developer](docs/frontend/developerclient.md), 
    - [QA engineer](docs/frontend/qaengineerclient.md), 
    - [tech support](docs/frontend/techsupportclient.md).
- Types of client applications by deployment type: web, desktop, mobile (Xamarin, Android), telegram bot.
- Description of backend services: 
    - [authentication API](docs/backend/authbackend.md), 
    - [customer backend](docs/backend/customerbackend.md), 
    - [kitchen backend](docs/backend/kitchenbackend.md), 
    - [warehouse backend](docs/backend/warehousebackend.md), 
    - [courier backend](docs/backend/courierbackend.md), 
    - [manager backend](docs/backend/managerbackend.md), 
    - [HR backend](docs/backend/hrbackend.md), 
    - [financial backend](docs/backend/financialbackend.md), 
    - [marketing backend](docs/backend/marketingbackend.md), 
    - [admin backend](docs/backend/adminbackend.md), 
    - [developer backend](docs/backend/developerbackend.md), 
    - [QA engineer backend](docs/backend/qaengineerbackend.md), 
    - [tech support backend](docs/backend/techsupportbackend.md), 
    - [system backend](docs/backend/systembackend.md), 
    - [file service](docs/backend/fileservice.md), 
    - [statistical backend](docs/backend/statisticalbackend.md), 
    - [predictive backend](docs/backend/predictivebackend.md), 
    - [notifications](docs/backend/notificationsbackend.md).
- Description of process patterns (you can read more about process patterns at [this link](docs/processpatterns/README.md)): 
    - [delivering](docs/processpatterns/delivering.md),
    - [information](docs/processpatterns/information.md),
    - [maintenance](docs/processpatterns/maintenance.md),
    - [transmitting file](docs/processpatterns/transmittingfile.md),
    - [requesting](docs/processpatterns/requesting.md).
- Types of payment: 
    - cash upon receipt, 
    - through a validator upon receipt, 
    - through the bank's application using a QR code, 
    - in the application using CVC.
- Upload files to the server (images, videos, Word, Excel, PDF).
- Download files from the server (images, Word, Excel, PDF).
- Sending notifications about promotions via email and/or Telegram.
<!--
- Generation of a QR code for payment.
- Displaying information on orders in the form of lists: a list of all orders, information on a specific order (actual time of registration, cooking and delivery; estimated time of cooking and delivery, total order amount, cost of order items, delivery place; status).
- Statistics on many orders in the form of dashboards (by time: day, week, month, year, all time; by type of charts: Line chart, Bar chart, Histogram, Scatter plot, etc.; metrics: total order amount, cost positions, number of orders, number of positions, time of ordering, place of delivery).
- Metrics for internal use: the actual time of ordering, cooking and delivery; the total amount of the order, the value of the order items, the number of orders, the number of items, the time of ordering, the place of delivery, the place of user registration.
- Predictive models for all metrics: for a group of users (filter: city, country, age, gender, matches in users' full name, place of delivery, place of registration; display: list of users, brief information about the user).
- Tracking the location of the courier.
-->

### Technical requirements for the system

- Distributed system for storing records in the database: make an analysis of the database, which is optimal for writing and reading.
- Several storage types: SQL, sessions, file storage.
- Load balancing - Load balancer.
- Web (ASP.NET Core MVC + React), desktop (WPF), [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot).
- Using gRPC, RabbitMQ, ElasticSearch, WebAPI and worker.
- RabbitMQ can have multiple "subscribers".
- Asynchronous and multithreading programming (for example, when forming images).
- External services: 
    - [workflow-auth](https://github.com/alexeysp11/workflow-auth), 
    - [workflow-lib](https://github.com/alexeysp11/workflow-lib)
    <!--, Firebase, email delivery service, payment gateway.-->

### General system model

This diagram displays a list of client applications, backend services and databases, as well as the general principle of interaction between them.

The diagram notes that the admin backend service is infrastructural and has access to all backend services and databases within the platform, so all the functionality that is necessary for all IT specialists basically goes through the admin backend service.

The principle of naming modules is also indicated.

![system_overall](docs/img/system_overall.png)

### Simplified diagram of the layers 

This diagram demonstrates in more detail the principle on which the dynamism of the platform is based in the context of choosing the type of client application (MVC, Blazor, WPF etc) and the data transfer protocol between backend services (WebAPI, gRPC).

It is also indicated how asynchronous communication between services is carried out by dividing the functionality of controllers into `RequestController` and `ResponseController` in order to implement API methods.

![layers_simplified](docs/img/layers_simplified.png)

## Project configuration

To download this project and all its dependencies, you must sequentially execute the following commands on the command line:
```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
git clone https://github.com/alexeysp11/workflow-auth.git
git clone https://github.com/alexeysp11/delivery-service-csharp.git
```

## Docs

- [TODO](docs/TODO.md)
- [Contributing to projects](https://docs.github.com/en/get-started/quickstart/contributing-to-projects)
- [GitHub flow](https://docs.github.com/en/get-started/quickstart/github-flow)
