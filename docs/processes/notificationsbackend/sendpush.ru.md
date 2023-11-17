# sendpush

[English](sendpush.md) | [Русский](sendpush.ru.md)

Наименование: **Отправка пуш-уведомлений пользователям**.

Сценарий, отвечающий за уведомление пользователей с использованием пуш-уведомлений. 

Данный сценарий не стоит путать с сценарием [notifymanual](../notificationsbackend/notifymanual.ru.md), поскольку [notifymanual](../notificationsbackend/notifymanual.ru.md) ответственен за ручное уведомление пользователями внутри компании, в то время как [sendpush](../notificationsbackend/sendpush.ru.md) использутеся для автоматического уведомления всех пользователей системы (в том числе потребителей и потенциальных покупателей). 

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [бэкенд-сервис](../../backend/notificationsbackend.ru.md)

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [getnotified](../notificationsbackend/getnotified.ru.md) |

## Описание процесса

![maintenance_overall](../../img/maintenance_overall.png)

### Пошаговое выполнение

- Бэкэнд-сервис выполняет предварительную обработку запроса для того, чтобы проверить его на наличие ошибок.
- В случае отсутствия ошибок, выполняется цикл, в котором для каждого пользователя системы, указанном в списке адресатов, вызывается процесс [getnotified](../notificationsbackend/getnotified.ru.md).

![notificationsbackend.sendpush](../../img/activitydiagrams/notificationsbackend.sendpush.png)
