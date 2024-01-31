# initializedbefcore

[English](README.md) | [Русский](README.ru.md)

A program for the first initialization of the database for the delivery service application.
Data initialization is performed using Entity Framework Core.

## Performing migrations

In order to perform the migration, you can run the following commands:
```
dotnet ef migrations add <MigrationName> --project ../../src/core/DeliveryService.Core.csproj
dotnet ef database update --project ../../src/core/DeliveryService.Core.csproj
```
