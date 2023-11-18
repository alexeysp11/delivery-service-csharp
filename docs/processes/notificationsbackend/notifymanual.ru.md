# notifymanual

[English](notifymanual.md) | [Русский](notifymanual.ru.md)

Наименование: **Отправка уведомлений пользователям вручную**.

Сценарий, отвечающий за уведомление сотрудников менеджером в компании, занимающейся доставкой, включает отправку сообщений или оповещений сотрудникам через приложение управления или другие каналы связи для предоставления обновлений о расписаниях, задачах или другой важной информации.

Паттерн процесса: [requesting](../../processpatterns/requesting.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/managerclient.md), [бэкэнд-сервис](../../backend/managerbackend.md).

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

## Описание процесса

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### Пошаговое выполнение

- Менеджер открывает приложение.
- Менеджер выбирает опцию "Уведомить сотрудников".
- Система предложит менеджеру уточнить детали уведомления.
- Подробности об уведомлении сообщает менеджер.
- Система отправляет уведомление всем сотрудникам.

![warehouse.reportincident](../../img/activitydiagrams/warehouse.reportincident.png)
