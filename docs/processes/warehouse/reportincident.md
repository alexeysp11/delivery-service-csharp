# reportincident

[English](reportincident.md) | [Русский](reportincident.ru.md)

Warehouse client application: Report incident.

The scenario responsible for reporting incidents by warehouse employees involves providing a mechanism for employees to report safety hazards, accidents, or other incidents that occur in the warehouse. 
This could be done through a mobile app or web interface that allows employees to submit incident reports with relevant details.

Macro process: [requesting](../../macroprocesses/requesting.md)

Responsible modules: [client application](../../frontend/warehouseclient.md), [backend service](../../backend/warehousebackend.md).

## Process description

The overall description of the scenario for incident reporting in the warehouse backend service is that it allows warehouse staff to report any incidents that occur in the warehouse, such as accidents, equipment malfunctions, or theft. 

The interactive steps within the scenario include selecting the type of incident, providing a description of what happened, and submitting the incident report. 

![requesting_overall](../../img/requesting_overall.png)

### Step-by-step execution

- Warehouse employee opens the app.
- Employee selects "Report Incident" option.
- The system prompts the employee to provide details about the incident.
- The employee provides details about the incident.
    - Select the type of incident that occurred (accident, accident, equipment malfunction, product damage, theft, or other).
    - Provide a text description of what happened.
    - Submit the incident report to notify management and other staff of the incident.
- The system stores the incident report in the database.
- The system sends a notification to the manager about the incident.

![warehouse.reportincident](../../img/activitydiagrams/warehouse.reportincident.png)

## Data

### Objects

- Incident
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- DeliveryService

### DTOs

- IncidentDTO
