# makepayment 

Read this in other languages: [English](makepayment.md), [Russian/Русский](makepayment.ru.md). 

Customer client application: make a payment.

The description of the **client application** is presented at [this link](../../frontend/customerclient.md).

## Process description

The [customer app](../../frontend/customerclient.md) allows users to make payments for their orders using different payment methods.

### Step-by-step execution

- When the customer places their order, they need to select their preferred payment method (see [makeorder](makeorder.md)).
- If they choose **cash on delivery**, they confirm the order and pay the courier when they receive their order.
- If they choose **POS when receiving**, they confirm the order and pay using their credit or debit card when they receive the order.
- If they choose **using QR code**, they scan the QR code provided by the app and confirm the payment.
    - The [customer backend service](../../backend/customerbackend.md) sends a request to [fileservice](../../backend/fileservice.md) to generate a QR code for payment.
- If they choose **using CVC**, they enter their card details and confirm the payment.
    - Add payment geteway after filling out the form if a card is selected as a type of payment.
- The app confirms the payment and sends to the backend service.
