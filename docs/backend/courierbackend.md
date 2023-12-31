# courierbackend

[English](courierbackend.md) | [Русский](courierbackend.ru.md)

`courierbackend` is a backend service that is responsible for delivering orders to customers. 

The overall description of the [courier backend service](courierbackend.md) is that it controls the delivery process from the store to the customer, and allows couriers to sign in to their account, scan the QR code on their delivery backpack to start the delivery process, manage deliveries from the store to the warehouse, receive notifications about incidents that occur during delivery, and report any incidents that occur on the job.

Other possible functionalities of the service include tracking courier performance metrics, managing courier schedules, scanning the QR code on the order, navigating to the delivery location, updating the delivery status in the app, and providing training resources for new couriers.

[Client app](../frontend/courierclient.md)

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)

## Flowchart steps

- [Scan the QR code on the order](../flowchartsteps/delivering/scanqronorder.md)
- [Scan the QR code on the backpack](../flowchartsteps/delivering/scanbackpack.md) (to mark the start/end of work)
- [Delivery of the order to the customer](../flowchartsteps/delivering/deliverorder.md)
- [Delivery from store to warehouse](../flowchartsteps/delivering/store2wh.md)
- [Update the delivery status](../flowchartsteps/delivering/updatedeliverystatus.md)
- [Notify about an incident](../processes/systembackend/reportincident.md)
