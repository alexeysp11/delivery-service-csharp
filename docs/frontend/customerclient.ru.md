# customerclient

[English](customerclient.md) | [Русский](customerclient.ru.md)

`customerclient` — это клиентское приложение, которое используется клиентами для просмотра продуктов, размещения заказов и отслеживания поставок.

[Бэкенд-сервис](../backend/customerbackend.ru.md)

## Общая модель системы

![system_overall](../img/system_overall.png)

## Описание приложения

- Коммуницирует напрямую со следующими бэкенд сервисами:
    - [authentication API](../backend/authbackend.ru.md), 
    - [customer backend](../backend/customerbackend.ru.md), 
    - [file service](../backend/fileservice.ru.md), 
    - [statistical backend](../backend/statisticalbackend.ru.md), 
    - [predictive backend](../backend/predictivebackend.ru.md), 
    - [notifications](../backend/notificationsbackend.ru.md).
- Виды оплаты:
    - наличная при получении, 
    - через валидатор при получении, 
    - через приложение банка по QR-коду,
    - в приложении с помощью CVC.

## Процессы

- [Вход](../processes/auth/signin.ru.md)
- [Регистрация](../processes/customer/signup.ru.md)
- [Аккаунт пользователя](../processes/customer/useraccount.ru.md)
- [Оформление заказа](../processes/customer/makeorder.ru.md)
- [Совершить оплату](../processes/customer/makepayment.ru.md)
- [Все заказы](../processes/customer/orders.ru.md): отображение информации/статистики по предыдущим заказам в виде списков и дашбордов
- [Текущие заказы](../processes/customer/pendingorders.ru.md): отслеживание статуса заказа
- [Отменить заказ](../processes/customer/cancelorder.md)
- [Настройки](../processes/customer/settings.ru.md)
- [Получение пуш-уведомлений](../processes/customer/pushnotifications.ru.md)
- [Просмотр видео](../processes/customer/watchingvideos.ru.md)
