# courierclient

Доступно на других языках: [English/Английский](courierclient.md), [Russian/Русский](courierclient.ru.md). 

`courierclient` — это клиентское приложение, которое используется водителями-курьерами для управления маршрутами и доставками.

Описание бэкенд-сервиса приложения для курьера представлено по [данной ссылке](../backend/courierbackend.ru.md).

## Общая модель системы

![system_overall](../img/system_overall.png)

## Описание приложения

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Отсканировать QR-код на рюкзаке](../processes/courier/scanbackpack.ru.md) (для отметки начала/конца работы)
- [Доставка заказа потребителю](../processes/courier/deliverorder.ru.md)
- [Доставка из магазина на склад](../processes/courier/store2wh.ru.md)
