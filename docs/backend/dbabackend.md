# dbabackend

[English](dbabackend.md) | [Русский](dbabackend.ru.md)

`dbabackend` is a backend service that allows DBA to manage databases.

[Client app](../frontend/dbaclient.md)

## Overall description of the system 

Monitoring systems in the database:
- disk space
- queues in pgbouncer
- loss of replica
- replica lag
- raid array errors
- number of long autovacuum processes

Crowns:
- replication lag
- forced stopped requests
- daily report on queries in the database

Tasks:
- conducting schema migrations to the database
- deleting/archiving large tables
- issuance of rights
- creation of new databases (major/minor versions)
- search for anomalies in reports for each database
     - the load has increased
     - the request/report did not arrive
     - new requests appeared
     - the request began to be executed more often
     - the request began to consume more CPU
     - the request began to consume more disks

![system_overall](../img/system_overall.png)

## Processes 
