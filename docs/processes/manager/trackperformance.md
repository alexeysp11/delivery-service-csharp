# trackperformance

[English](trackperformance.md) | [Русский](trackperformance.ru.md)

Name: **Track performance**.

The scenario responsible for tracking performance of employees and delivery strategies by manager in the delivery service company involves collecting data on delivery times, customer satisfaction, employee productivity, and other relevant metrics, analyzing the data to identify trends and areas for improvement, and implementing changes to improve performance.

Process pattern: [information](../../processpatterns/information.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Dependencies

### Influences on

| Backend service | Process |
| --- | ---- |
| [statisticalbackend](../../backend/statisticalbackend.md) | [employeeperformance](../statisticalbackend/employeeperformance.md) |

## Process description

Overall performance of the company could be estimated by tracking metrics such as revenue growth rate, customer retention rate, and market share. Performance metrics could be used for planning strategies to scale up the company by identifying areas for improvement and setting goals for improvement.

![information_overall](../../img/information_overall.png)

### Step-by-step execution

- A manager opens the delivery service app and navigates to the backend service for managers.
- The manager selects the option to view performance metrics.
- The app displays real-time data on order volume, delivery times, and customer satisfaction ratings.
- The manager can filter the data by location, time period, or other relevant factors.
- The app also provides recommendations for improving performance based on the data analysis.
- The manager can use this information to make data-driven decisions and optimize business operations.

![manager.trackperformance](../../img/activitydiagrams/manager.trackperformance.png)

## Data structures

### Objects

- [EmployeePerformance](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/EmployeePerformance.cs)
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs): this object could represent both manager and employee

### DTOs

- PerformanceTrackingDTO
    PerformanceTrackingDTO could have properties like employeeName, employeeID, performanceRating, performanceDate, managerName, managerID, etc. 
