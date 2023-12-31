# managepermissions

[English](managepermissions.md) | [Русский](managepermissions.ru.md)

Наименование: **Управлять разрешениями**.

Сценарий, отвечающий за управление разрешениями администратора в компании, занимающейся доставкой, включает настройку учетных записей пользователей с соответствующими уровнями доступа к различным системам и данным, изменение разрешений по мере необходимости и обеспечение предоставления доступа только авторизованным пользователям.

Паттерн процесса: [requesting](../../processpatterns/requesting.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/adminclient.ru.md), [бэкенд-сервис](../../backend/adminbackend.ru.md)

Версия платформы: v0.1

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [adminbackend](../../backend/adminbackend.ru.md) | [dbreplication](../admin/dbreplication.ru.md) |

## Описание процесса

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### План пошагового выполнения процесса

- Администратор открывает приложение.
- Администратор выбирает опцию "Управление разрешениями".
- Система отображает список сотрудников и их текущие права.
- Администратор выбирает сотрудника и обновляет его разрешения.
- Система обновляет права сотрудников в базе данных.

![admin.managepermissions](../../img/activitydiagrams/admin.managepermissions.png)
