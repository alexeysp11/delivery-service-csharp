# reportincident 

[English](reportincident.md) | [Русский](reportincident.ru.md)

Name: **Report incident**.

The scenario responsible for reporting an incident by couriers involves providing a mechanism for users to report safety hazards, accidents, or other incidents. 
This could be done through a mobile app or web interface that allows couriers to submit incident reports with relevant details.

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [backend service](../../backend/systembackend.md)

Infuences on: 
- [notificationsbackend](../../backend/notificationsbackend.md)
    - [sendnotifications](../notificationsbackend/sendnotifications.md)

## Process description

The overall description of the scenario for incident notification in the courier backend service is that it allows users to report any incidents: 
- delivery process: accidents, theft, or damaged goods;
- warehouse: accidents, equipment malfunctions, or theft.

The interactive steps within the scenario include selecting the type of incident, providing a description of what happened, and submitting the incident report. 

![requesting_overall](../../img/requesting_overall.png)

### Step-by-step execution

- User opens the app.
- User selects "Report Incident" option.
- The system prompts the employee to provide details about the incident.
- The employee provides details about the incident.
    - Select the type of incident that occurred (accident, equipment malfunction, product damage, theft, or other).
    - Provide a text description of what happened.
    - Submit the incident report to notify management and other staff of the incident.
- The system stores the incident report in the database.
- The system sends a notification to the manager about the incident.

![warehouse.reportincident](../../img/activitydiagrams/warehouse.reportincident.png)

## Data

### Objects

- [Incident](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Incident.cs)
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs)
- DeliveryService
    - DeliveryService object could have properties like name, contact information, delivery area, etc. 

### DTOs

- IncidentDTO
    - IncidentDTO could have properties like incidentType, location, date, severity, serviceName, serviceContactInfo, etc.
