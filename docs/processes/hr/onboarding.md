# onboarding

[English](onboarding.md) | [Русский](onboarding.ru.md)

Name: **Onboarding**.

The onboarding process for new employees involves providing the necessary training and resources for them to integrate into their roles within the delivery service app effectively.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/hrclient.md), [backend service](../../backend/hrbackend.md)

Platform version: v0.2

## Dependencies

### Depends on

| Backend service | Process |
| --- | ---- |
| [hrbackend](../../backend/hrbackend.md) | [candidateselection](../hr/candidateselection.md) |

### Influences on

| Backend service | Process |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.md) | [sendnotifications](../notificationsbackend/sendnotifications.md) |

## Process description

The stages of employee onboarding:
- Pre-boarding: preparation for onboarding;
- 1st day: new employee welcome;
- 1st week: introduction to company, people and role;
- 1st month: education and training;
- 2nd month: check-in and feedback;
- 3rd month: check-in and feedback;
- 6th month: check-in and feedback.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution

- A request is received to the backend service to start onboarding an employee (as parameters: personal information, interview results, notes and recommendations)
- Welcoming a new employee to the company (done via newsletter).
- Ensuring access to necessary training materials and resources.
- Assign a mentor or buddy to guide the new candidate through their onboarding process.
- Evaluate the candidate's readiness to integrate into their roles in the company.
- At the beginning of the 2nd week, send the adaptation plan to the employee, the employee must sign it (the adaptation plan indicates the main check points and evaluation criteria).
- Track progress and completion of training modules.
- In a timely manner, the system sends a notification to the employee, manager and HR specialist about the need to hold a meeting to collect feedback.
- At any time during onboarding, the manager can signal problems during the adaptation of a specialist.

![hr.onboarding](../../img/activitydiagrams/hr.onboarding.png)
