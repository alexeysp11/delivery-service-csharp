# TODO 

- **Pictures** could be added for all types of **users** (for example, add a new field in DB table).
- **Client applications store cache and session tokens**, so create mechanism for data replication (backend to client app).
- **Communication between services** using **message broker** could be possible only if each backend service has its own database.
- Add **JWT** + **Microsoft** and **Google** OAuth-based authentication.
- When communicating through the network, sometimes you can use the idea of **pipelining**:
![HTTP_pipelining](https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/HTTP_pipelining2.svg/1200px-HTTP_pipelining2.svg.png)
- Add recepes into DB for customer app.
- Add overall description of warehouse, kitchen and courier apps/backend services.
- Add algorithms to handle exceptions to the diagrams.
- Probably, it's better to move [signin](processes/customer/signin.md) and [signup](processes/customer/signup.md) into the folder that stores data for authentication service.
- Use [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md) for [customer backend](backend/customerbackend.md) and [client-side customer app](frontend/customerclient.md).
- Add the [delivery_customer_tmp_cb](dbtables/customer/delivery_customer_tmp_cb.md) table.
- Edit [delivery_whproduct_whb](dbtables/warehouse/delivery_whproduct_whb.md).

## Roadmap for the project 

- Scenarios for client-side apps and backend:
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
