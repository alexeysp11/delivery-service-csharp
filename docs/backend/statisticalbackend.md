# statisticalbackend

[English](statisticalbackend.md) | [Русский](statisticalbackend.ru.md)

`statisticalbackend` is a backend service that provides data analysis.

The statistical service in the delivery service app is responsible for collecting, preprocessing, analyzing, and visualizing data to provide insights into the performance of the company and its employees. 

The backend service responsible for performing statistical operations in the delivery service app is a statistical analysis service. Its possible functionalities include:

- Data collection and storage
- Data preprocessing and cleaning
- Statistical analysis and modeling
- Data visualization and reporting
- Predictive analytics

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Service description

Statistical backend service and predictive backend service could be implemented as a single backend service, but it may be more efficient to separate them into two services to improve scalability and maintainability.

Use case scenarios for statistical service could include:
- Estimating the performance of employees and the company within a certain period of time using methods such as regression analysis and time series analysis.
- Analyzing customer feedback to identify patterns and trends in their satisfaction levels using methods such as sentiment analysis and clustering.
- Identifying the most popular delivery routes and times to optimize delivery schedules using methods such as network analysis and data visualization.

Getting reports:
- Financial reports in the business report would include information about revenue, expenses, profitability, and cash flow. 
- Operational reports would provide data on the performance of the delivery service, such as delivery times and order accuracy. 
- Customer satisfaction reports would provide feedback from customers about their experience with the delivery service. 
- Inventory reports would detail the current stock levels of products. 
- Employee performance reports would provide information on the productivity and efficiency of employees. Such business report could also be retreived within the [trackperformance](../processes/manager/trackperformance.md) process.

## Processes

- [Estimate employee performance](../processes/statisticalbackend/employeeperformance.md)
- [Analyze customer feedback](../processes/statisticalbackend/analyzecustomerfeedback.md)
- [Identify most popular delivery routes](../processes/statisticalbackend/populardevileryroutes.md)
