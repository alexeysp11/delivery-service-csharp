# customerclient

Доступно на других языках: [English/Английский](customerclient.md), [Russian/Русский](customerclient.ru.md). 

`customerclient` - это клиентское приложения для потребителей.

## Требования к системе и её описание 

### Общая модель системы

![system_overall](../img/system_overall.png)

### Описание приложения

- Интегрируется напрямую с [authentication API](../backend/authbackend.ru.md), [customer backend](../backend/customerbackend.ru.md), [file service](../backend/fileservice.ru.md), [statistical model](../backend/statisticalmodel.ru.md), [predictive model](../backend/predictivemodel.ru.md), [email sender](../backend/emailsender.ru.md), [push notifications](../backend/pushnotifications.ru.md).
- Процессы:
    - Аккаунт пользователя.
    - [Оформление заказа](processes/customer.makeorder.ru.md).
    - [Все заказы](processes/customer.orders.ru.md): отображение информации/статистики по предыдущим заказам в виде списков и дашбордов.
    - [Текущие заказы](processes/customer.pendingorders.ru.md): отслеживание статуса заказа.
    - [Настройки](processes/customer.settings.ru.md).
    - Получение пуш-уведомлений.
    - Просмотр видео.
- Виды оплаты:
    - наличная при получении, 
    - через валидатор при получении, 
    - через приложение банка по QR-коду,
    - в приложении с помощью CVC.

Описание **бэкенд-сервиса** для данного приложения представлено по [данной ссылке](../backend/customerbackend.ru.md).

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Регистрация

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

### Вход в приложение 

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
