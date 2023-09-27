# authbackend

Доступно на других языках: [English/Английский](authbackend.md), [Russian/Русский](authbackend.ru.md). 

`authbackend` - бэкенд для сервиса аутентификации 

## Требования к сервису и его описание 

### Общая модель системы

![system_overall](../img/system_overall.png)

### Контекст использования сторонних сервисов аутентификации

![](../img/authentication.png)

### Описание сервиса

- В качестве сервиса аутентификации используется [workflow-auth](https://github.com/alexeysp11/workflow-auth).
- Данный сервис производит запись/чтение сессионных токенов в БД и через брокер сообщений уведомляет сервисы, в которых критично наличие токенов, об изменениях в БД, связанных с токенами (например, в число таких сервисов входят [customer backend](customerbackend.ru.md), [kitchen backend](kitchenbackend.ru.md), [courier backend](courierbackend.ru.md), [manager backend](managerbackend.ru.md)).
- К данному сервису могут обращаться все клиентские приложения, приведенные на рисунке выше в разделе "End user applications": [customer](../frontend/customerclient.ru.md), [kitchen](../frontend/kitchenclient.ru.md), [courier](../frontend/courierclient.ru.md), [manager](../frontend/managerclient.ru.md), [admin](../frontend/adminclient.ru.md).
