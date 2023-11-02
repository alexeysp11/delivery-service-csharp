# dbreplication

[English](dbreplication.md) | [Русский](dbreplication.ru.md)

The scenario for database replication by admin in the delivery service company.

Macro process: [maintenance](../../macroprocesses/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- Log into the system as admin
- Access the database replication tool
- Admin selects the source and target databases to replicate
- System establishes a connection between the source and target databases
- System initiates the data transfer process and monitors its progress
- System verifies the data integrity and consistency between the source and target databases
- Admin confirms the successful replication and activates the target database
