# TODO 

- &cross; **Pictures** could be added for all types of **users** (for example, add a new field in DB table).
- &cross; **Client applications store cache and session tokens**, so create mechanism for data replication (backend to client app).
- &cross; **Communication between services** using **message broker** could be possible only if each backend service has its own database.
- &cross; Add **JWT** + **Microsoft** and **Google** OAuth-based authentication.
- &cross; When communicating through the network, sometimes you can use the idea of **pipelining**:
![HTTP_pipelining](https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/HTTP_pipelining2.svg/1200px-HTTP_pipelining2.svg.png)
- &cross; Add recipes into DB for customer app.
- &cross; Add overall description of warehouse, kitchen and courier apps/backend services.
- &cross; Add algorithms to handle exceptions to the diagrams.
- &check; Probably, it's better to move [signin](processes/auth/signin.md) and [signup](processes/customer/signup.md) into the folder that stores data for authentication service.
- &cross; Use [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs) for [customer backend](backend/customerbackend.md) and [client-side customer app](frontend/customerclient.md).
- &cross; Add SKU and ASN classes for the [warehousebackend](backend/warehousebackend.md) service.
- &check; Place the sections "Related modules" and "Human-readable name" just after languages.
- &check; Create the common diagram that shows interaction between services in order to retrieve some data for customer client-side app (e.g. orders, pending orders, settings, user account, watching videos).
- &check; Create a diagram that could be used to explain how services intract with each other, in order to send and/or retrive some push or email notifications.
- &check; Create a diagram that explains how the products are delivered to the kitchen, how the order is prepared, and how it is delivered to the customer.
- &cross; Implement parsing of QR code.
- &cross; Building the most optimal delivery route and displaying the courier's location on the map could be implemented in this application.
- &cross; You can add a link to the client application in the documentation for processes.
- &cross; Describe what processes and process patterns are, how they are divided into backend services; how it is determined which backend service a particular process will belong to.
- &cross; Write "Getting started" guide for the project.
- &cross; In the DBA backend, `pg_stat_statements` could be used for getting daily report on queries. Also `log_min_duration` could be used when it comes to logging those statements whose execution time is too big.
- &cross; Platform migration to Linux system.
- &cross; Consider to use the following architecture for interaction between microservices:
![iiko-architecture](https://habrastorage.org/webt/qh/bu/qt/qhbuqtdm4-uylhriivfq3vwpfyq.png)

## Roadmap for the project 

- Scenarios for client-side apps and backend:
    - customer,
    - warehouse,
    - courier,
    - kitchen,
    - admin,
    - manager.
- Classes and DB tables for stroring data on the backend services and client-side apps.
- DTOs.
- Cache tables.
- Code: 
    - services: gRPC, WebAPI.
    - clients: ASP.NET MVC, WPF, Telegram.
    - Some of the payment methods should be implemented later (e.g. QR code, CVC).
