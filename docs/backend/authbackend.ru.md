# authbackend

Доступно на других языках: [English/Английский](authbackend.md), [Russian/Русский](authbackend.ru.md). 

`authbackend` - бэкенд для сервиса аутентификации.

## Требования к сервису и его описание 

### Общая модель системы

![system_overall](../img/system_overall.png)

### Контекст использования сторонних сервисов аутентификации

![authentication](../img/authentication.png)

### Описание сервиса

- В качестве сервиса аутентификации используется [workflow-auth](https://github.com/alexeysp11/workflow-auth).
- В целях упрощения модели системы предположим, что все бэкенд сервисы используют одну и ту же БД. Поэтому информацию по наименованию таблиц и их полей можно прочитать в описании соответствующего сервиса (например, в число таких сервисов входят [customer backend](customerbackend.ru.md), [kitchen backend](kitchenbackend.ru.md), [courier backend](courierbackend.ru.md), [manager backend](managerbackend.ru.md)).
<!--
- Данный сервис производит запись/чтение сессионных токенов в БД и через брокер сообщений уведомляет сервисы, в которых критично наличие токенов, об изменениях в БД, связанных с токенами.
-->

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Регистрация

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

### Вход в приложение 

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
