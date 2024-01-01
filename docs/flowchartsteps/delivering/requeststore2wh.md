# requeststore2wh

[English](requeststore2wh.md) | [Русский](requeststore2wh.ru.md)

Name: **Request delivery of an order from the store to the warehouse**.

A scenario responsible for requesting delivery of goods from the store to the warehouse by couriers in the event that the warehouse does not have enough ingredients to prepare the order.

Flowchart name: [delivering](../../flowchartsteps/delivering/README.md)

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md)

Platform version: v0.1

## Dependencies

### Depends on

### Influences on

## Process description

This process provides the implementation of the [delivering](../../flowchartsteps/delivering/README.ru.md) process pattern:

![delivering_overall](../../img/processpatterns/delivering_overall.png)

### Flowcharts for network communication

![overall.delivering](../../img/flowcharts/overall.delivering.png)

### Step-by-step execution plan of the process

### Sequence diagrams

![delivering.requeststore2wh](../../img/sequencediagram/delivering.requeststore2wh.png)
