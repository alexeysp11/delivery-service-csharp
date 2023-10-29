# courierbackend

Read this in other languages: [English](courierbackend.md), [Russian/Русский](courierbackend.ru.md). 

`courierbackend` is a backend service that is responsible for delivering orders to customers. 

The overall description of the [courier backend service](courierbackend.md) is that it controls the delivery process from the store to the customer, and allows couriers to sign in to their account, scan the QR code on their delivery backpack to start the delivery process, manage deliveries from the store to the warehouse, receive notifications about incidents that occur during delivery, and report any incidents that occur on the job.

Other possible functionalities of the service include tracking courier performance metrics, managing courier schedules, scanning the QR code on the order, navigating to the delivery location, updating the delivery status in the app, and providing training resources for new couriers.

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Scan the QR code on the order](../processes/courier/scanqronorder.md)
- [Scan the QR code on the backpack](../processes/courier/scanbackpack.md) (to mark the start/end of work)
- [Delivery of the order to the customer](../processes/courier/deliverorder.md)
- [Delivery from store to warehouse](../processes/courier/store2wh.md)
- [Update the delivery status](../processes/courier/updatedeliverystatus.md)
- [Notify about an incident](../processes/courier/reportincident.md)
