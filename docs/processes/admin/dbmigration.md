# dbmigration

[English](dbmigration.md) | [Русский](dbmigration.ru.md)

Name: **Database migration**.

The process responsible for migrating data from one database to another.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

## Process description

![maintenance_overall](../../img/maintenance_overall.png)

### Step-by-step execution

- Analyzing the current database structure and data
- Designing the new database structure
- Creating a backup of the current database
- Performing the migration process
- Verifying the data integrity and functionality
- Testing the new database thoroughly
- Implementing the new database in the production environment
