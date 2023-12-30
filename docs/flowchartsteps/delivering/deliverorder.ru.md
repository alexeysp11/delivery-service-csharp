# deliverorder

[English](deliverorder.md) | [Русский](deliverorder.ru.md)

Наименование: **Доставка заказа потребителю**.

Сценарий, отвечающий за доставку заказа клиенту курьерами, предполагает использование мобильного приложения или устройства с поддержкой GPS для навигации к местоположению клиента, своевременную и профессиональную доставку заказа и получение всех необходимых подписей или других доказательств доставки.

Наименование flowchart-диаграммы: [delivering](../../flowchartsteps/delivering/README.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/courierclient.ru.md), [бэкэнд-сервис](../../backend/courierbackend.ru.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [customerbackend](../../backend/customerbackend.ru.md) | [preprocessorder](../delivering/preprocessorder.ru.md) |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [updatedeliverystatus](../delivering/updatedeliverystatus.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [scanbackpack](../delivering/scanbackpack.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [scanqronorder](../delivering/scanqronorder.ru.md) |
| [customerbackend](../../backend/customerbackend.ru.md) | [makepayment](../delivering/makepayment.ru.md) |

## Описание процесса

Данный процесс ответственен за предоставление информации по заказам, которые несёт/нёс курьер (номер заказа, место доставки, фактическое/ориентировочное время доставки).

Функциональность, которая может быть добавлена в следующих версиях платформы:
- Построение наиболее оптимального маршрута для доставки.
- Отображение местоположения курьера на карте.

![delivering_overall](../../img/flowchartnames/delivering_overall.png)

### Flowchart-диаграммы для сетевого взаимодействия

![overall.delivering](../../img/flowcharts/overall.delivering.png)

### План пошагового выполнения процесса

- Курьер открывает приложение на своем устройстве.
- Курьер выбирает заказ доставки, над которым работает.
- Курьер регистрирует рюкзак и заказ, запуская процессы [scanbackpack](scanbackpack.ru.md) и [scanqronorder](scanqronorder.ru.md).
- Запускается процесс [updatedeliverystatus](../delivering/updatedeliverystatus.ru.md) для того, чтобы начать доставку.
- Курьер перемещается к адресу доставки, используя функцию карты приложения.
- Курьер доставляет заказ покупателю и получает подпись или код подтверждения.
- Курьер отмечает в системе заказ на доставку как выполненный.
- Когда курьер отмечает заказ как выполненный, запускается процесс [updatedeliverystatus](../delivering/updatedeliverystatus.ru.md) для того, чтобы закончить доставку.

![courier.deliverorder](../../img/activitydiagrams/courier.deliverorder.png)

### Диаграммы последовательности

![courier.deliverorder](../../img/sequencediagram/courier.deliverorder.png)
