# dbmigration

[English](dbmigration.md) | [Русский](dbmigration.ru.md)

Name: **Database migration**.

The process responsible for migrating data from one database to another.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.1

## Process description

Data migration stages:
- Planning: closely acces the data sources and choose the ideal approach for your migration process (migration could be automated or manual).
- Data evaluation: check the quality of data and the tools.
- Source-destination mapping.
- Data backup: backup your data before migration to avoid data loss.
- Execution:
    - Extract data from source.
    - Intermediate staging data.
    - Load into destination table.
- Testing: perform regular testing to maintain data quality.
- Post-migration auditing: conduct a detailed auditing of the data to ensure data integrity.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution

- Analyzing the current database structure and data
- Designing the new database structure
- Creating a backup of the current database
- Performing the migration process
- Verifying the data integrity and functionality
- Testing the new database thoroughly
- Implementing the new database in the production environment
