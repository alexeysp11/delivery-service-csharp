# majorchangerequest

[English](majorchangerequest.md) | [Русский](majorchangerequest.ru.md)

Name: **Major change request**.

A scenario that is responsible for logging and tracking the execution of requests that involve significant changes to the system (such requests are called **major change requests**).

It can be beneficial to separate change requests based on the scale of changes required. 
For example, large-scale change requests that involve architectural solutions or significant work could be categorized as [major change requests](../admin/majorchangerequest.md), while smaller changes such as database modifications or minor updates could be categorized as [minor change requests](../admin/minorchangerequest.md). 
This can help in prioritizing and managing change requests more effectively.

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.3

## Process description

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Step-by-step execution plan of the process

- Establish a system for logging and tracking requests that involve significant changes to the system, such as software updates or configuration changes.
- Require detailed documentation and approval for significant changes before they are implemented.
- Regularly review logs and reports of significant changes to ensure compliance with company policies and standards.

![Change-Request-Management-Workflow](https://www.researchgate.net/profile/Zafar-Nasir/publication/224191064/figure/fig1/AS:302594669989893@1449155599842/Change-Request-Management-Workflow.png)
