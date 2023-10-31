# scanbackpack

Read this in other languages: [English](scanbackpack.md), [Russian/Русский](scanbackpack.ru.md). 

Courier client application: scan backpack QR code.

The scenario responsible for scanning QR code on backpack before delivering by couriers involves using a mobile app or handheld scanner to scan a unique QR code associated with each courier's backpack. 
This verifies that the correct courier is making the delivery and provides real-time tracking information to the delivery service company and the customer.

Responsible modules: [client application](../../frontend/courierclient.md), [backend service](../../backend/courierbackend.md).

## Process description

- Registration of a backpack by scanning a QR code (in order to register the beginning / end of work during the day and track the location of the courier in real time).

![placing_order_overall](../../img/placing_order_overall.png)

### Step-by-step execution

- The courier opens the app on their device.
- The courier selects the delivery order they are working on.
- The courier scans the QR code on the backpack using their device's camera.
- The system verifies the QR code and confirms that it matches the delivery order.
