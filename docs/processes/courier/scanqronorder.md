# scanqronorder

[English](scanqronorder.md) | [Русский](scanqronorder.ru.md)

Name: **Scan QR code on order**.

The scenario responsible for scanning QR code on order before delivering by couriers involves using a mobile app or handheld scanner to scan a unique QR code associated with each order. 
This verifies that the correct order is being delivered and provides real-time tracking information to the delivery service company and the customer.

Process pattern: [delivering](../../processpatterns/delivering.md)

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md)

Platform version: v0.1

## Dependencies

### Depends on

| Backend service | Process |
| --- | ---- |
| [courierbackend](../../backend/courierbackend.md) | [deliverorder](../courier/deliverorder.md) |

## Process description

![delivering_overall](../../img/processpatterns/delivering_overall.png)

Despite the fact that this process belongs to the macroprocess [delivering](../../processpatterns/delivering.ru.md), the implementation of this process is similar to the processes included in the macroprocess [maintenance](../../processpatterns/maintenance.ru.md), in the context of user notification:

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Flowcharts for network communication

![overall.delivering](../../img/flowcharts/overall.delivering.png)

### Step-by-step execution plan of the process

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier scans the QR code on the delivery order using their device's camera.
- The system verifies the QR code and displays the details of the delivery order to the courier.

![courier.scanqronorder](../../img/activitydiagrams/courier.scanqronorder.png)

### Sequence diagrams

![courier.scanqronorder](../../img/sequencediagram/courier.scanqronorder.png)

## Data structures

| Object | DTO | Database table |
| --- | ---- | --- |
| QRCode | - | - |
| [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs) | - | - |
| [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs) | - | - |
| - | DeliveryStartDTO | - |

- QRCode object could have properties like codeValue, expirationDate, etc. 
- Order object could have properties like orderNumber, customer details, product details, QR code, etc. 
- Courier object could have properties like name, ID, vehicle type, etc. 
- DeliveryStartDTO could have properties like orderNumber, courierName, qrCodeValue, deliveryDate, etc.
