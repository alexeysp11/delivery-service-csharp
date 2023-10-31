# useraccount 

[English](useraccount.md) | [Русский](useraccount.ru.md)

Customer client application: user account.

Macro process: [information](../../macroprocesses/information.md)

Responsible modules: [client application](../../frontend/customerclient.md)

## Process description

- The controller processes the request and stores the user data necessary for display on the UI.
- As such, a step-by-step description for this process is not implied, because the necessary data about the user was received during authentication and stored [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal) as [ClaimTypes](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimtypes) (see process [signin](signin.md)).
- The following fields are displayed:
    - login,
    - email,
    - phone.
- Some fields are also displayed on the [settings](settings.md) page.

![information_overall](../../img/information_overall.png)
