# courierbackend

Доступно на других языках: [English/Английский](courierbackend.md), [Russian/Русский](courierbackend.ru.md). 

`courierbackend` — это бэкенд сервис, который отвечает за доставку заказов клиентам.

Описание клиентского приложения для курьера представлено по [данной ссылке](../frontend/courierclient.ru.md).

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Описание приложения

- Получает информацию о местоположении курьера.

## Процессы 

- [Вход](../processes/customer/signin.ru.md)
- [Отсканировать QR-код на рюкзаке](../processes/courier/scanbackpack.ru.md) (для отметки начала/конца работы)
- [Доставка заказа потребителю](../processes/courier/deliverorder.ru.md)
- [Доставка из магазина на склад](../processes/courier/store2wh.ru.md)
