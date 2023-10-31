# warehouseclient

[English](warehouseclient.md) | [Русский](warehouseclient.ru.md)

`warehouseclient` - это клиентское приложение, которое используется сотрудниками склада для управления запасами и выполнения заказов.

Клиентское приложение, используемое сотрудниками склада компании, занимающейся доставкой, позволяет им управлять уровнями запасов, выполнять запросы других отделов и отслеживать поставки на склад и со склада.

Описание основного **бэкенд-сервиса** для данного приложения представлено по [данной ссылке](../backend/warehousebackend.ru.md).

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Описание приложения

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Рассчитать продукцию](../processes/warehouse/calculateproducts.md)
- [От WH до кухни](../processes/warehouse/fromwhtokitchen.md)
