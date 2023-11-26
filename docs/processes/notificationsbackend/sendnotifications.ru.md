# sendnotifications

[English](sendnotifications.md) | [Русский](sendnotifications.ru.md)

Наименование: **Отправка уведомлений**.

Сценарий отправки уведомлений в компании службы доставки.

Сценарий, отвечающий за уведомление пользователей с использованием разных способов связи (начиная от пуш-уведомлений и заканчивая сообщениями по электронной почте). 

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [бэкенд-сервис](../../backend/systembackend.ru.md)

Версия платформы: v0.1

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendemail](../notificationsbackend/sendemail.ru.md) |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendpush](../notificationsbackend/sendpush.ru.md) |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendmsgtelegram](../notificationsbackend/sendmsgtelegram.ru.md) |

## Описание процесса

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### План пошагового выполнения процесса

- Пользователь запускает событие, требующее отправки уведомления (например, подтверждение заказа, обновление доставки).
- Система определяет тип и содержание уведомления в зависимости от события.
- Система получает настройки уведомлений и контактную информацию пользователя.
- Система формирует уведомление и форматирует его в соответствии с предпочтениями пользователя и возможностями устройства.
- Система отправляет уведомление на предпочтительный канал пользователя (например, электронная почта, push-уведомление, SMS).
- Система отслеживает статус доставки уведомлений и сообщает о любых ошибках или проблемах.

![notificationsbackend.sendnotifications](../../img/activitydiagrams/notificationsbackend.sendnotifications.png)
