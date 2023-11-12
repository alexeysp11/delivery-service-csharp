# managerbackend

[English](managerbackend.md) | [Русский](managerbackend.ru.md)

`managerbackend` is a backend service that provides analytics and reporting tools for business owners.

The backend service for managers in the delivery service app provides a comprehensive view of all orders, inventory levels, and delivery status across multiple locations. 

It allows managers to track performance metrics, manage inventory levels, track delivery times, and receive notifications when products are running low or when there are delays in delivery, and optimize delivery routes/methods. 
The service also provides analytics and reporting capabilities to help managers make data-driven decisions and improve overall business operations.

Additionally, it provides analytics and reporting capabilities to help managers optimize inventory management and improve delivery efficiency.

[Client app](../frontend/managerclient.md)

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Processes 

- [Sign in](../processes/auth/signin.md)
- [Start employee search](../processes/manager/startemployeesearch.md)
- [Termination of employment](../processes/manager/terminationofemployment.md)
- [Manage relationships with suppliers](../processes/manager/supplierrelationships.md)
- [Track performance](../processes/manager/trackperformance.md)
- [Receive notifications about problems](../processes/notificationsbackend/getnotified.md)
- [Generate business report](../processes/manager/businessreport.md)
- [Notify employees](../processes/notificationsbackend/notifymanual.md)
- [Change planned inventories](../processes/manager/inventorylevels.md)
- [Optimize delivery](../processes/manager/optimizedelivery.md)
- [Approval](../processes/manager/approval.md)
