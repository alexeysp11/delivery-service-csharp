# startemployeesearch

[English](startemployeesearch.md) | [Русский](startemployeesearch.ru.md)

Name: **start employee search**.

The scenario responsible for starting employee search by manager involves using the management app to search for employees based on various criteria, such as name, department, or location. 
This allows managers to quickly find and communicate with the right employees for specific tasks or projects.

Macro process: [organizational](../../macroprocesses/organizational.md)

Responsible modules: [client application](../../frontend/managerclient.md), [backend service](../../backend/managerbackend.md).

## Process description

- External services that could be used for getting information about potential candidates when searching for a new employee by manager in the delivery service company include job posting websites (e.g. Indeed, Glassdoor), recruiting agencies, and professional networking sites (e.g. LinkedIn).

![organizational_overall](../../img/organizational_overall.png)

### Step-by-step execution

- The manager opens the delivery service app and navigates to the backend service for managers.
- The manager selects the option to start employee search.
- The app displays a search bar where the manager can input employee names, job titles, or other relevant keywords.
- The app returns a list of employees that match the search criteria.
- The manager can view employee profiles, including contact information, job history, and performance metrics.
- The manager can use this information to make informed decisions about scheduling, promotions, or disciplinary actions.
- If there are multiple candidates for a position, the system notifies HR to schedule interviews with each candidate.
- After interviews are conducted, the interviewers provide feedback and ratings for each candidate.
- The manager reviews the feedback and ratings and selects the most suitable candidate for the position.
- The system notifies the chosen candidate and HR to proceed with the hiring process.

## Data

### Objects

- EmployeeSearch
    - EmployeeSearch object could have properties like searchCriteria, searchResults, etc. 
- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- Candidate
    - Employee object could have properties like name, ID, role, skills, etc. 
- [EmploymentContract](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business.BusinessDocuments/EmploymentContract.md)

### DTOs

- EmployeeSearchDTO
    - EmployeeSearchDTO could have properties like searchCriteria, employeeName, employeeID, employeeRole, employeeSkills, etc.
