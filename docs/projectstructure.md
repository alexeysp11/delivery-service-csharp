# projectstructure

[English](projectstructure.md) | [Русский](projectstructure.ru.md)

This file describes the structure of the project in general (product applications: client applications, backend services; infrastructure backend services), and also lists the functionality that applies to each application.

## Placement and processing of delivery orders

### Grocery applications

#### Client applications

- functionality that is needed to place an order on the **customer** client application.
     - display of a list of orders (UI: &cross;; controller: &cross;; BL: &cross;).
     - place an order (UI: &check;; controller: &cross;; BL: &check;).
     - pay for the order (UI: &cross;; controller: &cross;; BL: &check;).
- functionality that is needed to process an order on the **courier** client application.
     - displaying a list of delivery orders (UI: &cross;; controller: &cross;; BL: &cross;).
     - perform delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &check;).
     - deliver the order to the customer (UI: &cross;; controller: &cross;; BL: &check;).
- functionality that is needed to process an order on the **kitchen** client application.
     - displaying a list of orders that need to be prepared (UI: &cross;; controller: &cross;; BL: &cross;).
     - prepare an order (UI: &cross;; controller: &cross;; BL: &check;).
- functionality that is needed to process an order on the **warehouse** client application.
     - displaying a list of delivery orders from the store to the warehouse that need to be requested (UI: &cross;; controller: &cross;; BL: &cross;).
     - displaying a list of orders for delivery from the store to the warehouse that need to be confirmed (UI: &cross;; controller: &cross;; BL: &cross;).
     - displaying a list of orders for delivery from the warehouse to the kitchen (UI: &cross;; controller: &cross;; BL: &cross;).
     - displaying a list of orders for delivery from the kitchen to the warehouse (UI: &cross;; controller: &cross;; BL: &cross;).
     - request delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &check;).
     - confirm delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &check;).
     - perform delivery from the warehouse to the kitchen (UI: &cross;; controller: &cross;; BL: &check;).
     - perform delivery from the kitchen to the warehouse (UI: &cross;; controller: &cross;; BL: &check;).

#### Backend services

- functionality that is needed to process an order on the **customer** backend service.
     - place an order (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
     - pay for the order (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
- functionality that is needed to process an order on the **courier** backend service.
     - perform delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
     - deliver the order to the customer (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
- functionality that is needed to process an order on the **kitchen** backend service.
     - prepare an order (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
- functionality that is needed to process an order on the backend service of the **warehouse**.
     - request delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
     - confirm delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
     - perform delivery from the warehouse to the kitchen (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
     - perform delivery from the kitchen to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).

### Infrastructure backend services

- functionality that is needed to process an order on the backend service for files.
    - get file.
- functionality that is needed to process an order on the backend service for notifications.
    - send a notification to the user.

## See also

The project structure could be as follows: 

```
- data
- dbinit
- docs
- examples
- src
    - authentication
    - frontend
        ...
        - customer
            - bl
            - blazor
            - mvc
            - wpf
        ...
    - backend
        ...
        - customer
            - bl
            - grpc
            - webapi
        ...
        - fileservice
        - notifications
        ...
    - telegrambot
    - core
    - models
- tests
    - frontend
        - customerclientbl
    - backend
        - customerbackendbl
```
