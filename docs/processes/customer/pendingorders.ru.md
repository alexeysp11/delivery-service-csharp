# pendingorders

[English](pendingorders.md) | [Русский](pendingorders.ru.md)

Наименование: **Текущие заказы**.

Общее описание сценария отслеживания заказа в серверной службе клиентов заключается в том, что он позволяет клиентам отслеживать ход выполнения их заказа от обработки до доставки.

Интерактивные шаги в рамках сценария включают просмотр обновлений статуса заказа в режиме реального времени, отслеживание местоположения курьера на карте и получение уведомлений, когда заказ готов к доставке или уже доставлен.

Паттерн процесса: [information](../../processpatterns/information.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

Версия платформы: v0.1

## Описание процесса

Данный процесс почти полностью повторяет [просмотр всех заказов](../customer/orders.ru.md), за исключением того, что для отображения на данной форме заказы фильтруются по статусу: необходимо, чтобы было "Обрабатывается", "В процессе готовки", "В доставке".

![information_overall](../../img/processpatterns/information_overall.png)

### План пошагового выполнения процесса

См. [просмотр всех заказов](../customer/orders.ru.md).

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Структуры данных

| Объект | DTO |
| --- | ---- |
| [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs) | - |
| [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/ProductCategory.cs) | - |
| [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs) | DeliveryOrderDTO |
