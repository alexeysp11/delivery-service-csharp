# rateorder

[English](rateorder.md) | [Русский](rateorder.ru.md)

Наименование: **Оценить заказ**.

Общее описание сценария оценки и проверки заказа в серверной службе клиентов заключается в том, что он позволяет клиентам оставлять отзывы о качестве своего заказа, опыте доставки и общем обслуживании.

Интерактивные шаги в рамках сценария включают выбор звездного рейтинга, написание обзора и отправку отзыва.

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

Версия платформы: v0.1

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

## Описание процесса

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### План пошагового выполнения процесса

- Сотрудник доставки обновляет статус заказа и сигнализирует о завершении доставки (это реализовано в рамках процесса [updatedeliverystatus](../delivering/updatedeliverystatus.ru.md)).
- Система отправляет клиенту уведомление с просьбой оценить заказ.
- Клиент оценивает заказ на основе своего опыта.
- Система сохраняет рейтинг в базе данных.
- Система обновляет общий рейтинг ресторана.
- Если рейтинг ниже определенного порога, система отправляет уведомление менеджеру ресторана.

![customer.rateorder](../../img/activitydiagrams/customer.rateorder.png)
