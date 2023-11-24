# scanqronorder

[English](scanqronorder.md) | [Русский](scanqronorder.ru.md)

Наименование: **Сканировать QR-код на заказе**.

Сценарий сканирования QR-кода заказа перед доставкой курьером предполагает использование мобильного приложения или портативного сканера для сканирования уникального QR-кода, связанного с каждым заказом.
Это подтверждает, что доставляется правильный заказ, и предоставляет информацию об отслеживании в режиме реального времени компании, занимающейся доставкой, и клиенту.

Паттерн процесса: [delivering](../../processpatterns/delivering.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/courierclient.md), [бэкэнд-сервис](../../backend/courierbackend.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [courierbackend](../../backend/courierbackend.ru.md) | [deliverorder](../courier/deliverorder.ru.md) |

## Описание процесса

![delivering_overall](../../img/processpatterns/delivering_overall.png)

Несмотря на то, что данный процесс относится к макропроцессу [delivering](../../processpatterns/delivering.ru.md), реализация данного процесса схожа с процессами, входящими в макропроцесс [maintenance](../../processpatterns/maintenance.ru.md), в контексте уведомления пользователя:

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Пошаговое выполнение

- Курьер открывает приложение на своем устройстве.
- Курьер выбирает заказ доставки, над которым работает.
- Курьер сканирует QR-код в заказе на доставку с помощью камеры своего устройства.
- Система проверяет QR-код и отображает детали заказа на доставку курьеру.

![courier.scanqronorder](../../img/activitydiagrams/courier.scanqronorder.png)

### Диаграммы последовательности

![courier.scanqronorder](../../img/sequencediagram/courier.scanqronorder.png)
