# warehousebackend 

[English](warehousebackend.md) | [Русский](warehousebackend.ru.md)

`warehousebackend` — это бэкенд сервис, который занимается управлением запасами и выполнением заказов.

Серверная служба склада для приложения службы доставки позволяет сотрудникам склада входить в свою учетную запись, рассчитывать количество продукции, управлять запасами продуктов, необходимых для приготовления еды, управлять поставками со склада на кухню, получать уведомления об изменении количества продукции и сообщать о происшествиях, происходящих на складе.

Другие возможные функции сервиса включают создание отчетов о запасах, отслеживание сроков годности продукции и управление отношениями с поставщиками.

Описание **клиентского приложения** представлено по [данной ссылке](../frontend/warehouseclient.ru.md). 

## Общая модель системы

![system_overall](../img/system_overall.png)

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Рассчитать продукцию](../processes/warehouse/calculateproducts.ru.md)
- [Отслеживание сроков годности продукции](../processes/warehouse/trackexpirationdate.ru.md)
- [От WH до кухни](../processes/warehouse/fromwhtokitchen.ru.md)
- [От кухни на склад](../processes/warehouse/fromkitchentowh.ru.md)
- [Доставить из магазина на склад](../processes/courier/store2wh.ru.md)
- [Уведомлять об изменении количества товара](../processes/warehouse/notifyproductqtychanges.ru.md)
- [Уведомить об инциденте](../processes/warehouse/reportincident.ru.md)
- [Создать отчет об инвентаризации](../processes/warehouse/inventoryreport.ru.md)
