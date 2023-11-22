# survey

[English](survey.md) | [Русский](survey.ru.md)

Name: **Survey**.

The survey business process in a delivery service app involves collecting feedback from customers, delivery personnel, or other stakeholders to gather insights, assess satisfaction levels, and identify areas for improvement. 

This process typically includes designing survey questionnaires, distributing surveys through various channels (such as email or app notifications), collecting responses, analyzing data, and taking action based on survey findings. 

The goal is to continuously improve service quality, customer experience, and operational efficiency based on feedback gathered through surveys.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Platform version: v0.1

## Process description

Before starting this process, you must notify the user that they need to complete the survey.
You can notify the user using the [sendnotifications](../notificationsbackend/sendnotifications.md) process.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution

- Identify the stakeholders from whom feedback needs to be collected (customers, delivery personnel, etc.)
- Design feedback forms or surveys to gather insights and assess satisfaction levels
- Implement the feedback collection mechanism within the delivery service app
- Communicate the feedback collection process to stakeholders and encourage participation
- Collect and compile feedback data
- Analyze feedback data to identify areas for improvement
- Implement necessary changes based on the feedback received

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)
