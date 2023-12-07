# courierclient

[English](courierclient.md) | [Русский](courierclient.ru.md)

`courierclient` — это клиентское приложение, которое используется курьерами для управления маршрутами и доставками.

Клиентское приложение, используемое курьерами в компании, занимающейся доставкой, позволяет им просматривать назначенные им доставки и управлять ими, сообщать клиентам детали доставки и обновлять статус доставок по мере их завершения.

[Бэкенд-сервис](../backend/courierbackend.ru.md)

## Общая модель системы

![system_overall](../img/system_overall.png)

## Описание приложения

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Отсканировать QR-код на рюкзаке](../flowchartsteps/delivering/scanbackpack.ru.md) (для отметки начала/конца работы)
- [Доставка заказа потребителю](../flowchartsteps/delivering/deliverorder.ru.md)
- [Доставка из магазина на склад](../flowchartsteps/delivering/store2wh.ru.md)
