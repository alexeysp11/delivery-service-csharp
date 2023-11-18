# pendingorders

[English](pendingorders.md) | [Русский](pendingorders.ru.md)

Наименование: **Текущие заказы**.

Общее описание сценария отслеживания заказа в серверной службе клиентов заключается в том, что он позволяет клиентам отслеживать ход выполнения их заказа от обработки до доставки.

Интерактивные шаги в рамках сценария включают просмотр обновлений статуса заказа в режиме реального времени, отслеживание местоположения курьера на карте и получение уведомлений, когда заказ готов к доставке или уже доставлен.

Паттерн процесса: [information](../../processpatterns/information.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

## Описание процесса

Данный процесс почти полностью повторяет [просмотр всех заказов](../customer/orders.ru.md), за исключением того, что для отображения на данной форме заказы фильтруются по статусу: необходимо, чтобы было "Обрабатывается", "В процессе готовки", "В доставке".

![information_overall](../../img/processpatterns/information_overall.png)

### Пошаговое выполнение

См. [просмотр всех заказов](../customer/orders.ru.md).

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Структуры данных

| Объект | DTO | Таблица в БД |
| --- | ---- | --- |
| [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs) | - | [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md) |
| [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/ProductCategory.cs) | - | [delivery_category_cb](../../dbtables/customer/delivery_category_cb.md) |
| [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs) | DeliveryOrderDTO | [delivery_order_cb](../../dbtables/customer/delivery_order_cb.md) |
