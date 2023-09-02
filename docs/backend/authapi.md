# authapi

Read this in other languages: [English](authapi.md), [Russian/Русский](authapi.ru.md). 

Authentication API 

## Service requirements and description

Overall description of the system: 

![system_overall](../img/system_overall.png)

Description of API for authentication:
- This service writes / reads session tokens to the database and through the message broker notifies services in which the availability of tokens is critical about changes in the database related to tokens (for example, such services include [customer backend](customerbackend.md ), [kitchen backend](kitchenbackend.md), [courier backend](courierbackend.md), [manager backend](managerbackend.md)).
- This service can be accessed by all client applications shown in the figure above in the "End user applications" section: [customer](../frontend/customerclient.md), [kitchen](../frontend/kitchenclient .md), [courier](../frontend/courierclient.md), [manager](../frontend/managerclient.md), [admin](../frontend/adminclient.md ).
- RabbitMQ is used as a message broker.
- PostgreSQL is used as a database.
- In order to reduce the risk of personal data compromise, the service does not store any user-related data: only user GUIDs, as well as tables related to authentication ("session token", "temporary registration", "suspicious registration").
- Only the "code check" table is stored on the client application.
- Session token fields (in the form of an object and tables in the database):
    - generated token GUID,
    - start / end of the token,
    - GUID of the user (relevant only for the table on the service).
- Temporary registration fields:
    - user GUID,
    - generated token GUID,
    - start / end of the token,
    - registration confirmation code,
    - time of sending the confirmation code,
    - the number of attempts to enter the registration code,
    - time of sending a request for temporary registration from the client application,
    - outdated registration,
    - overwritten registration,
    - registration closing code (success, refusal to provide a confirmation code, the number of attempts to confirm the code has been exhausted, fell off by timeout, overwritten, canceled).
- Suspicious registration fields: repeats temporary registration fields.
- Code validation fields (relevant only on consumer client):
    - GUID of the token,
    - start / end of the token,
    - registration confirmation code,
    - time of sending the confirmation code,
    - the number of attempts to enter,
    - obsolete,
    - overwritten,
    - closing code: possible values are the same as for the similar temporary registration field.
- Jobs:
    - Marking entries in the registration code check table on the client application as outdated and moving to the service (every 15-30 minutes): if the time the request was sent was earlier than the recheck duration and not closed.
    - Copying suspicious records from a temporary registration to a table with a suspicious registration (1 time per day): if there were N or more not closed as successful.
    - Removal of obsolete entries from checking the registration code on the client application and temporary registration on the service (1-7 times a week).
- Any new login to the application updates the expiration date of the session token.

Description of requests:
- On a GET request from a client application (to create a new session token): receives an empty request, generates a session token as a GUID object, converts it to a string value and writes it to the database, after which it returns the token object as a response
- When a POST request is made from a client application (to get all the information on the session token in the database): receives a request with a GUID, converts it to a string value and checks for the presence/relevance of such an entry in the database, in case of absence/outdated entry generates a new GUID , then returns the token object

## Step-by-step description of the work of the client application and service

### Registration in the application

Registration in the application is possible only for consumers, and for company personnel (couriers, kitchen staff, managers, administrators) - the account is entered manually by the main administrator.

Sequencing:
1. The user opens the application and selects registration.
2. The user enters a login, email, phone number and password (the password is entered twice).
    - Validation of the entered values is performed on the form.
    - If the validation fails, then an error message is displayed (stay on the form and give the user the opportunity to enter the data again).
    - If the validation is successful, then a request is sent to the authentication service with a JSON object (fields: login, email, phone, password, date/time) to create a user.
    - Before creating a user, it is checked whether such a user exists in the database.
    - If the user does not exist in the database, then the user record is added to the database, then a token is generated, added to the database and bound to the user ID, after that the service returns information on the created token (GUID, start and end date/time of the token).
    - If the login already exists, then the message "Unfortunately, a user with the same name already exists. Please try again."
    - If the email and/or phone already exists in the database, then the message "A user with this email and/or phone number already exists. For data security reasons, deactivate the previous account or try to remember the password for the previous account" and the choice "Remember password" "/"Deactivate old entry"/"Cancel".
    - If the user clicks "Remember password", then he is redirected to the application login form.
    - If the user clicks "Deactivate Old Entry", the active entries in the user and token tables are marked as obsolete and overwritten, and a new user is created (the list of GUIDs of the overwritten tokens is sent as a response).
    - All changes at this stage are recorded in the temporary registration table.
3. A registration confirmation code is sent to the specified email/number.
    - The code is generated in the application, entered into the table of temporary values and sent by email/SMS.
    - If there are several unclosed records in the temporary table during the day with the same login/email/phone, then it is likely that the user is being hacked, so after the nth time the message should mention that this is the last time of the day.
4. The user is taken to the confirmation code entry page.
    - A request is sent to the service to receive a confirmation code.
    - The received response from the service is added to the database (mark the transferred tokens as overwritten).
5. The user enters a verification code.
    - The entered code is compared with the confirmation code from the service.
    - After each code comparison, the total number of attempts used is increased in the database located on the side of the client application.
    - You have 3-5 attempts to enter the confirmation code.
    - If the user closed the application, then after some time, the job on the client application will mark the entry as obsolete and send information to the service by confirmation code.
    - If the user, after closing, enters the application again, then he gets to the registration form and repeats all the actions again (the old attempt must be overwritten at the previous stage).
    - If the user canceled the input, then you need to mark the closing code in the database and send confirmation information to the service.
    - If the user could not confirm the code in 3-5 attempts, then a request is sent to the service to mark the record for the user as obsolete and enter the number of attempts, and after that the user is redirected to the registration form.
    - If the user has confirmed the code, then the entry in the temporary registration table is marked as closed.
6. The user is returned to the application login form.

### Login to the application

Any user can enter the application: both the end user and the company employee.

Sequencing:
1. The user opens the app and chooses to sign in.
2. User enters login/email/phone and password.
    - Validation of the entered values is performed on the form.
    - If the validation fails, then an error message is displayed (stay on the form and give the user the opportunity to enter the data again).
    - If the validation passed, then a request with a JSON object (fields: login/email/phone, password, date/time) is sent to the authentication service to confirm the entry.
    - If the user with the specified login/email/phone does not exist in the database, or the passwords are different, then the error message "Invalid login or password. Please try again" is displayed.
    - If login/email/phone and password are entered correctly, then the user receives a session token.
    - If, upon receipt of a session token, it turns out that it is expired, then its expiration date is simply updated, and it is also returned to the user.
3. The user enters the application.

## Methods for processing network requests on the side of the authentication service

Objects:
- User credentials: 
    - login, 
    - email, 
    - phone number, 
    - password.
- User existance: 
    - login exists, 
    - email exists, 
    - phone number exists, 
    - exception message.
- Session token:
    - token GUID, 
    - begin/end of token, 
    - activation code, 
    - datetime of code sending, 
    - overriden tokens,
    - exception message.
- Token info: 
    - token GUID, 
    - number of tries, 
    - deprecated, 
    - overriden, 
    - reason to close.
- Get code info response:
    - is successful, 
    - exception message.
- User ID response:
    - is verified, 
    - user ID, 
    - exception message.
- User ID request:
    - user ID.

Methods for signing up: 
- Check user existance (input: User credentials; output: User existance);
- Add user (input: User credentials; output: Session token);
- Get code info (input: Token info; output: Get code info response).

Methods for log in:
- Verify user credentials (input: User credentials; output: User ID response);
- Get token by user ID (input: User ID request; output: Session token).
