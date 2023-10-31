# settings 

[English](settings.md) | [Русский](settings.ru.md)

Customer client application: settings.

The personal settings scenario in the customer client app involves allowing users to view and edit their personal information, such as name, email address, and payment methods. 
The app securely stores this information and allows users to update it as needed.

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

Settings and personal data page:
- Personal information:
    - login (saved in [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), see [useraccount](useraccount.md)),
    - email (saved in [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), see [useraccount](useraccount.md)),
    - telephone (saved in [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), see [useraccount](useraccount.md)),
    - connected messengers: WhatsApp, Viber, Telegram,
    - nickname in Telegram,
    - preferred method of communication: e-mail, phone, one of the messengers,
- Payment:
    - preferred payment method,
    - linked cards.
- Usability:
    - default delivery location,
    - file extension for loading by default.
- Safety:
    - password (this parameter is empty by default).

You can also go to [user account](useraccount.md) to see some personal settings.

### Step-by-step execution

- The user opens "Settings".
- Some parameters are loaded from the [user account](useraccount.md) page, and some paraters are loaded from the database or [backend service](../../backend/customerbackend.md).
- The user changes settings.
- At the bottom of the page there is a button "Save changes".
    - Changes get to the services, after the response from the service - to the database.
    - After that, the user is shown on the interface: "Successful" or "An error occurred".

![customer.settings](../../img/activitydiagrams/customer.settings.png)
