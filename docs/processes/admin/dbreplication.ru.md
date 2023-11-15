# dbreplication

[English](dbreplication.md) | [Русский](dbreplication.ru.md)

Наименование: **Репликация базы данных**.

Сценарий репликации базы данных администратором в компании службы доставки.

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/adminclient.ru.md), [бэкенд-сервис](../../backend/adminbackend.ru.md)

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

## Описание процесса

![maintenance_overall](../../img/maintenance_overall.png)

### Пошаговое выполнение

- Войдите в систему как администратор.
- Доступ к инструменту репликации базы данных.
- Администратор выбирает исходную и целевую базы данных для репликации.
- Система устанавливает соединение между исходной и целевой базами данных.
- Система инициирует процесс передачи данных и контролирует его ход.
- Система проверяет целостность и согласованность данных между исходной и целевой базами данных.
- Администратор подтверждает успешную репликацию и активирует целевую базу данных.

![admin.dbreplication](../../img/activitydiagrams/admin.dbreplication.png)
