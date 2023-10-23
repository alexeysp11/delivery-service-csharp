# useraccount 

Read this in other languages: [English](useraccount.md), [Russian/Русский](useraccount.ru.md). 

Customer client application: user account.

The description of the **client application** is presented at [this link](../../frontend/customerclient.md).

## Process description

- The controller processes the request and stores the user data necessary for display on the UI.
- As such, a step-by-step description for this process is not implied, because the necessary data about the user was received during authentication and stored in `ClaimsPrincipal` (see process [signin](signin.md)).
