# customerclient

[English](customerclient.md) | [Русский](customerclient.ru.md)

`customerclient` — это клиентское приложение, которое используется потребителями для просмотра продуктов, размещения заказов и отслеживания поставок.

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
- [Аккаунт пользователя](../processes/systembackend/useraccount.ru.md)
- [Все заказы](../processes/customer/orders.ru.md): отображение информации/статистики по предыдущим заказам в виде списков и дашбордов
- [Текущие заказы](../processes/customer/pendingorders.ru.md): отслеживание статуса заказа
- [Отменить заказ](../processes/customer/cancelorder.md)
- [Настройки](../processes/customer/settings.ru.md)
- [Получение пуш-уведомлений](../processes/notificationsbackend/getnotified.ru.md)
- [Просмотр видео](../processes/fileservice/watchingvideos.ru.md)

## Flowchart-шаги

- [Оформление заказа](../flowchartsteps/delivering/makeorder.ru.md)
- [Совершить оплату](../flowchartsteps/delivering/makepayment.ru.md)
