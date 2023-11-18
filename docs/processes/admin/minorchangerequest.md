# minorchangerequest

[English](minorchangerequest.md) | [Русский](minorchangerequest.ru.md)

Name: **Minor change request**.

A scenario that is responsible for logging and tracking the execution of requests that involve minor changes to the system (such requests are called **minor change requests**).

It can be beneficial to separate change requests based on the scale of changes required. 
For example, large-scale change requests that involve architectural solutions or significant work could be categorized as [major change requests](../admin/majorchangerequest.md), while smaller changes such as database modifications or minor updates could be categorized as [minor change requests](../admin/minorchangerequest.md). 
This can help in prioritizing and managing change requests more effectively.

Process pattern: [requesting](../../processpatterns/requesting.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

## Process description

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Step-by-step execution

- Establish a system for logging and tracking requests that involve minor changes to the system, such as user account modifications or minor software updates.
- Require documentation of minor changes to ensure accountability and compliance with company policies.
- Regularly review logs and reports of minor changes to identify any potential issues or trends.

![Change-Request-Management-Workflow](https://www.researchgate.net/profile/Zafar-Nasir/publication/224191064/figure/fig1/AS:302594669989893@1449155599842/Change-Request-Management-Workflow.png)
