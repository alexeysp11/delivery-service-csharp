# trackexpirationdate

[English](trackexpirationdate.md) | [Русский](trackexpirationdate.ru.md)

Наименование: **Отслеживать срок годности**.

Сценарий, отвечающий за отслеживание сроков годности продуктов, хранящихся на складе, сотрудниками склада в компании службы доставки, предполагает использование программного обеспечения для управления запасами для отслеживания даты поступления и окончания срока годности каждого продукта.
Это позволяет сотрудникам склада следить за тем, чтобы продукция использовалась или продавалась до истечения срока годности, а также своевременно удалять просроченную продукцию со склада.

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/warehouseclient.md), [бэкенд-сервис](../../backend/warehousebackend.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [adminbackend](../../backend/adminbackend.ru.md) | |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

## Описание процесса

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### План пошагового выполнения процесса

- Сотрудник склада открывает приложение.
- Сотрудник выбирает продукт, который хочет отслеживать.
- Система проверяет базу данных запасов для этого продукта.
- Система отображает сотруднику срок годности продукта.
- Если срок годности продукта истек, система отправляет уведомление менеджеру ресторана о необходимости его утилизации.

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)
