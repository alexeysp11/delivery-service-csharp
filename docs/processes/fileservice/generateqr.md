# generateqr

[English](generateqr.md) | [Русский](generateqr.ru.md)

The scenario responsible for generating QR codes in the delivery service company involves creating unique codes for each order or package to enable tracking and verification. 

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [backend service](../../backend/fileservice.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

## Data 

### Objects 

- The QR code model could include properties such as code content and formatting. 
- The order information model could include properties such as order number, customer name, and delivery address. 
- The verification service could include methods for scanning and verifying QR codes.
