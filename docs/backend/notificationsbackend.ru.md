# notificationsbackend

[English](notificationsbackend.md) | [Русский](notificationsbackend.ru.md)

`notificationsbackend` — это бэкенд сервис, который обеспечивает общение с клиентами относительно их заказов посредством push-уведомлений и по электронной почте.

Бэкенд-сервис, отвечающий за отправку push-уведомлений сообщений электронной почты в приложении службы доставки. Его возможные функциональные возможности включают в себя:

- Push-уведомления:
    - Регистрация пользователей и управление устройствами
    - Составление и отправка уведомлений
    - Планирование и таргетинг уведомлений
    - Отслеживание уведомлений и отчетность
    - Персонализация и локализация уведомлений
- Электронные письма:
    - Составление и отправка электронных писем
    - Прием и обработка входящей электронной почты
    - Форматирование и оформление электронной почты
    - Вложения и ссылки электронной почты
    - Шаблоны электронной почты и автоматизация

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Процессы 

- [Отправка уведомлений](../processes/systembackend/sendnotifications.ru.md)
- [Уведомить](../processes/notificationsbackend/sendpush.ru.md)
- [Планирование уведомлений](../processes/notificationsbackend/notificationscheduling.ru.md)
- [Таргетинг уведомлений](../processes/notificationsbackend/notificationtargeting.ru.md)
- [Отправка электронной почты](../processes/notificationsbackend/sendemail.ru.md)
- [Получение пуш-уведомлений](../processes/notificationsbackend/getnotified.ru.md)
