# requeststore2wh

[English](requeststore2wh.md) | [Русский](requeststore2wh.ru.md)

Наименование: **Запросить доставку заказа из магазина на склад**.

Сценарий, отвечающий за запрос доставки товаров из магазина на склад курьерами в случае, если на складе не хватает ингридиентов для того, чтобы приготовить заказ.

Наименование flowchart-диаграммы: [delivering](../../flowchartsteps/delivering/README.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/courierclient.md), [бэкэнд-сервис](../../backend/courierbackend.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

### Влияет на

## Описание процесса

Данный процесс обеспечивает реализацию паттерна процессов [delivering](../../flowchartsteps/delivering/README.ru.md):

![delivering_overall](../../img/processpatterns/delivering_overall.png)

### Flowchart-диаграммы для сетевого взаимодействия

![overall.delivering](../../img/flowcharts/overall.delivering.png)

### План пошагового выполнения процесса

### Диаграммы последовательности

![delivering.requeststore2wh](../../img/sequencediagram/delivering.requeststore2wh.png)
