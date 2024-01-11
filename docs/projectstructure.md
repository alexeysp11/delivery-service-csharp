# projectstructure

## Grocery applications

### Client applications

- functionality that is needed to place an order on the **customer** client application.
    - place an order (UI: &check;; controller: &cross;; BL: &cross;).
    - pay for the order (UI: &cross;; controller: &cross;; BL: &cross;).
    - display of a list of orders (UI: &cross;; controller: &cross;; BL: &cross;).
- functionality that is needed to process an order on the **courier** client application.
    - perform delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &cross;).
    - deliver the order to the customer (UI: &cross;; controller: &cross;; BL: &cross;).
- functionality that is needed to process an order on the **kitchen** client application.
    - prepare an order (UI: &cross;; controller: &cross;; BL: &cross;).
- functionality that is needed to process an order on the **warehouse** client application.
    - request delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &cross;).
    - confirm delivery from the store to the warehouse (UI: &cross;; controller: &cross;; BL: &cross;).
    - perform delivery from the warehouse to the kitchen (UI: &cross;; controller: &cross;; BL: &cross;).
    - perform delivery from the kitchen to the warehouse (UI: &cross;; controller: &cross;; BL: &cross;).

### Backend services

- functionality that is needed to process an order on the **customer** backend service.
    - place an order (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - pay for the order (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - displaying a list of orders (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- functionality that is needed to process an order on the **courier** backend service.
    - perform delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - deliver the order to the customer (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- functionality that is needed to process an order on the **kitchen** backend service.
    - prepare an order (controller WebAPI: &cross; controller gRPC: &cross;; BL: &cross;).
- functionality that is needed to process an order on the backend service of the **warehouse**.
    - request delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - confirm delivery from the store to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - perform delivery from the warehouse to the kitchen (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - perform delivery from the kitchen to the warehouse (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).

## Infrastructure backend services

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
        - courier
        - customer
            - bl
            - blazor
            - mvc
            - wpf
    - backend
        - customer
            - bl
            - mvc
        - fileservice
        - pushnotifications
    - telegrambot
    - core
    - models
- tests
    - frontend
        - customerclientbl
    - backend
        - customerbackendbl
```
