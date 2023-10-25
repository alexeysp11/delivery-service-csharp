# courierclient

Доступно на других языках: [English/Английский](courier.md), [Russian/Русский](courier.ru.md). 

`courierclient` — это клиентское приложение, которое используется водителями-курьерами для управления маршрутами и доставками.

## Общая модель системы

![system_overall](../img/system_overall.png)

## Описание приложения

- Процессы:
    - [Вход](../processes/customer/signin.ru.md)
    - [Регистрация](../processes/customer/signup.ru.md)
    - [Отсканировать QR-код на рюкзаке](../processes/courier/scanbackpack.ru.md) (для отметки начала/конца работы).
    - [Доставка заказа потребителю](../processes/courier/deliverorder.ru.md).
    - [Доставка заказа из магазина на склад](../processes/courier/store2wh.ru.md).

Описание бэкенд-сервиса приложения для курьера представлено по [данной ссылке](../backend/courierbackend.ru.md).

## Процессы 

- [Вход](../processes/customer/signin.ru.md)
