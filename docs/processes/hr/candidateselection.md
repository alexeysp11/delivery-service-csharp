# candidateselection

[English](candidateselection.md) | [Русский](candidateselection.ru.md)

Name: **Candidate selection**.

The candidate selection process involves screening, selecting, and hiring candidates for different roles within the delivery service app, with a focus on using data-driven methods to make informed hiring decisions.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/hrclient.md), [backend service](../../backend/hrbackend.md)

Platform version: v0.2

## Dependencies

### Depends on

| Backend service | Process |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.md) | [startemployeesearch](../manager/startemployeesearch.md) |

### Influences on

| Backend service | Process |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.md) | [sendnotifications](../notificationsbackend/sendnotifications.md) |
| [hrbackend](../../backend/hrbackend.md) | [onboarding](../hr/onboarding.md) |

## Process description

Candidate screening methods: 
- Background checks,
- Resume screening,
- Cover letter screening,
- Application form,
- Video screening,
- Screening through phone calls,
- Pre-assessment tests,
- Personality tests,
- Written tests,
- Face-to-face interviews.

Short-listing matrix could be used in order to evaluate candidates.

The stages of the selection process: 
- Identifying hiring needs,
- Creating a recruitment plan,
- Setting up ads,
- Application,
- Screening and pre-selection,
- Interview,
- Assessment,
- References and background check,
- Decision,
- Job offer and contract,
- Onboarding.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution plan of the process

- A request comes to the backend service to open a new candidate (parameters: personal information, application form, resume, cover letter, application, preliminary tests, notes from HR).
- All information is validated and saved.
- If HR wants to view information on the selection process for a particular candidate, he/she can easily do so by navigating from the parent process to this process using the link.
- After adding a candidate to the system, HR schedules an interview with the candidate, and all interested employees are notified (the list of interested employees is passed as a parameter when initializing the process).
- Interested employees confirm their presence at the interview.
- Conduct initial interviews based on predefined criteria.
- After the interview, HR receives feedback from the managers who conducted the interview and rates the candidate in the system.
- Based on the assessment, a decision is made to hire a specialist.
- In case of a positive decision on hiring a candidate, HR informs the candidate of the decision, specifies the date of entry to work and sends him an offer.
- The candidate signs an employment contract, and from that moment the onboarding process begins (all signed documents are scanned and attached to the employee’s personal file).

![hr.candidateselection](../../img/activitydiagrams/hr.candidateselection.png)
