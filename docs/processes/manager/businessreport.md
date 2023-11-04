# businessreport

[English](businessreport.md) | [Русский](businessreport.ru.md)

Manager client application: business report.

The scenario responsible for getting business report by manager in the delivery service company involves generating reports that provide an overview of key business metrics, such as revenue, expenses, profitability, and customer satisfaction.

A business report in a delivery service company could consist of financial reports, operational reports, customer satisfaction reports, inventory reports, and employee performance reports. 
Different types of business reports could be used depending on the specific needs of the company.

Macro process: [organizational](../../macroprocesses/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md)

## Process description

- Financial reports in the business report would include information about revenue, expenses, profitability, and cash flow. 
- Operational reports would provide data on the performance of the delivery service, such as delivery times and order accuracy. 
- Customer satisfaction reports would provide feedback from customers about their experience with the delivery service. 
- Inventory reports would detail the current stock levels of products. 
- Employee performance reports would provide information on the productivity and efficiency of employees. Such business report could also be retreived within the [trackperformance](trackperformance.md) process.

![organizational_overall](../../img/organizational_overall.png)

### Step-by-step execution

- Manager opens the app.
- Manager selects "Business Report" option.
- The system retrieves the business data from the database.
- The system generates a report and displays it to the manager.

## Data 

### Objects 

- Financial data model: This model could include properties such as revenue, expenses, profitability, and cash flow. It could also have methods for calculating financial ratios and trends.
- Operational data model: This model could include properties such as delivery times, order accuracy, and customer satisfaction levels. It could also have methods for analyzing operational performance.
- Customer feedback model: This model could include properties such as customer ratings and comments. It could also have methods for sentiment analysis and clustering.
- Inventory levels model: This model could include properties such as product information and stock levels. It could also have methods for optimizing inventory management.
- [EmployeePerformance](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/EmployeePerformance.md)

### DTOs

