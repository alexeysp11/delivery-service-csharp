# customer.settings 

Read this in other languages: [English](settings.md), [Russian/Русский](settings.ru.md). 

Customer client application: settings.

The personal settings scenario in the customer client app involves allowing users to view and edit their personal information, such as name, email address, and payment methods. 
The app securely stores this information and allows users to update it as needed.

Related modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md).

## Process description

- Settings and personal data page:
    - Personal information:
        - login,
    - Communication:
        - email,
        - telephone,
        - connected messengers: WhatsApp, Viber, Telegram,
        - nickname in Telegram,
        - preferred method of communication: e-mail, phone, one of the messengers,
    - Payment:
        - preferred payment method,
        - linked cards.
    - Usability:
        - default delivery location,
        - file extension for loading by default (*maybe this parameter is not needed*).
    - Safety:
        - password.

### Step-by-step execution

- The user opens "Settings".
- The user scrolls through the list of settings, selects a category and a specific parameter.
- At the bottom of the page there is a button "Save changes".
    - Changes get to the services, after the response from the service - to the database.
    - After that, the user is shown on the interface: "Successful" or "An error occurred".

![customer.settings](../../img/activitydiagrams/customer.settings.png)
