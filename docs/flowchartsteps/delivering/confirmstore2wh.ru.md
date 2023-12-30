# confirmstore2wh

[English](confirmstore2wh.md) | [Русский](confirmstore2wh.ru.md)

Наименование: **Подтвердить доставку из магазина на склад**.

Сценарий, отвечающий за доставку товаров из магазина на склад курьерами, предполагает получение запросов на конкретные товары от сотрудников склада, покупку этих товаров в магазине, их упаковку для транспортировки и своевременную доставку на склад.

Наименование flowchart-диаграммы: [delivering](../../flowchartsteps/delivering/README.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/courierclient.md), [бэкэнд-сервис](../../backend/courierbackend.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

### Влияет на

## Описание процесса

Данный процесс обеспечивает реализацию паттерна процессов [delivering](../../flowchartsteps/delivering/README.ru.md):

![delivering_overall](../../img/flowchartnames/delivering_overall.png)

### Flowchart-диаграммы для сетевого взаимодействия

![overall.delivering](../../img/flowcharts/overall.delivering.png)

### План пошагового выполнения процесса

### Диаграммы последовательности

![delivering.confirmstore2wh](../../img/sequencediagram/delivering.confirmstore2wh.png)

![delivering.rejectstore2wh](../../img/sequencediagram/delivering.rejectstore2wh.png)
