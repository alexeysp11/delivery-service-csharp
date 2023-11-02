# reportincident 

[English](reportincident.md) | [Русский](reportincident.ru.md)

## Process description

![requesting_overall](../../img/requesting_overall.png)

### Step-by-step execution

![warehouse.reportincident](../../img/activitydiagrams/warehouse.reportincident.png)

## Data

### Objects

- Incident
    - Incident object could have properties like incidentType, location, date, severity, etc. 
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- DeliveryService
    - DeliveryService object could have properties like name, contact information, delivery area, etc. 

### DTOs

- IncidentDTO
    - IncidentDTO could have properties like incidentType, location, date, severity, serviceName, serviceContactInfo, etc.
