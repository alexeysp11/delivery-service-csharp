# dbtables

[English](README.md) | [Русский](README.ru.md)

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Design databases in the microservice architecture

There could be 3 main approaches how design databases in the microservice architecture. 
Each of the options for storing data in a microservice architecture has its own advantages and disadvantages.

### Using a separate database for each microservice

Using a separate database for each microservice provides strong isolation and autonomy for each service, but can lead to data duplication and consistency challenges. 

### Separating data by context

Taking into account that some of the microservices could use the same tables/instances, it could be resonable to separate data by context where the data is being used (e.g. data about financial operations that are related to customers could be separated from the data about the employee and their work).

So the following microservices could use the only "internal" database: [kitchenbackend](../backend/kitchenbackend.md), [warehousebackend](../backend/warehousebackend.md), [courierbackend](../backend/courierbackend.md). The following microserivces could use only customer related database: [customerbackend](../backend/customerbackend.md). The following microservices could use both database: [managerbackend](../backend/managerbackend.md), [adminbackend](../backend/adminbackend.md), [financialbackend](../backend/financialbackend.md), [statisticalbackend](../backend/statisticalbackend.md), [predictivebackend](../backend/predictivebackend.md).

Separating data by context can help manage data dependencies and improve performance, but may also introduce complexity in managing multiple databases. 

### Using a common database for all microservices

Using a common database for all microservices simplifies data management but can create tight coupling between services and hinder scalability. 

### Conclusions

Separating data by context is a better approach from a database design and performance perspective.

In addition, this solution allows, on the one hand, to reduce the close connection between services, and also to ensure a certain degree of isolation and autonomy of services by context.
And also on the other hand, reduce the problem of data duplication and consistency.

## Caching
