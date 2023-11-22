# clearcache

[English](clearcache.md) | [Русский](clearcache.ru.md)

Name: **Clear cache**.

Scenario for clearing cached data stored in databases associated with the corresponding microservices in a delivery service company.
This service can be performed either automatically or manually by the administrator.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.1

## Process description

In a microservice architecture, each microservice may have its own cache that stores data from external services or databases. 

When data in those external services or databases changes, the microservice needs to clear its cache to ensure that it has the most up-to-date data. 
This can be triggered by events or messages sent from the external services or databases.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution

- Manual Execution:
    - Admin logs into the backend system
    - Admin navigates to the cache management section
    - Admin selects the cache to be cleared or triggers a full cache clearance
    - Admin confirms the cache clearance action

- Automatic Execution:
    - Scheduled trigger or timer initiates cache clearance process
    - System automatically identifies and clears outdated or unnecessary cache data

## Data structures

The objects and DTOs used in this scenario would depend on the specific microservices and databases involved. 
Generally, there would be objects representing the cached data, as well as DTOs for communicating with external services or databases to retrieve updated data.
