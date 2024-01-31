# initializedbefcore

[English](README.md) | [Русский](README.ru.md)

Программа для первой инициализации базы данных для работы приложения сервиса доставки. 
Инициализация данных проиводится с использованием Entity Framework Core.

## Выполнение миграций

Для того, чтобы выполнить миграцию можно выполнить следующие команды:
```
dotnet ef migrations add <MigrationName> --project ../../src/core/DeliveryService.Core.csproj
dotnet ef database update --project ../../src/core/DeliveryService.Core.csproj
```
