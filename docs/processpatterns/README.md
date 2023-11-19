# processpatterns

[English](README.md) | [Русский](README.ru.md)

These types of diagrams show the general pattern of a process.

For example, some processes must start from the client application and only read data from the database, while other processes must wait for a request on the backend service and include, for example, approval chains.

In order to classify processes, typification was introduced based on how a separate process is implemented, as well as communication between microservices within it.

The following process patterns were identified:
- [delivering](delivering.md),
- [information](information.md),
- [maintenance](maintenance.md),
- [transmitting file](transmittingfile.md),
- [requesting](requesting.md).
