# authbackend

[English](authbackend.md) | [Русский](authbackend.ru.md)

`authbackend` — бэкенд сервис, отвечающий за управление входом и аутентификацией пользователей.

Внутренняя служба аутентификации, используемая клиентскими приложениями в компании, занимающейся доставкой, отвечает за проверку личности пользователей и предоставление доступа к определенным функциям и функциям на основе их разрешений.
Он использует стандартные протоколы шифрования и безопасности, чтобы гарантировать постоянную защиту пользовательских данных.

## Общая модель системы

![system_overall](../img/system_overall.png)

### Описание сервиса

- В качестве внешнего **сервиса аутентификации** используется [workflow-auth](https://github.com/alexeysp11/workflow-auth).
- В целях упрощения модели системы предположим, что все бэкенд сервисы используют одну и ту же БД. Поэтому информацию по наименованию таблиц и их полей можно прочитать в описании соответствующего сервиса (например, в число таких сервисов входят [customer backend](customerbackend.ru.md), [kitchen backend](kitchenbackend.ru.md), [courier backend](courierbackend.ru.md), [manager backend](managerbackend.ru.md)).
<!--
- Данный сервис производит запись/чтение сессионных токенов в БД и через брокер сообщений уведомляет сервисы, в которых критично наличие токенов, об изменениях в БД, связанных с токенами.
-->

## Интеграция с сервисом аутентификации 

Пример интеграции **сервиса аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth) с данным приложением представлено на рисунке ниже:

![authentication](../img/authentication.png)

### Регистрация

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

### Вход в приложение 

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Регистрация](../processes/customer/signup.ru.md)
