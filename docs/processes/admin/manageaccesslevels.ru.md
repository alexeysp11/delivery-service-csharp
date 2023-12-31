# manageaccesslevels

[English](manageaccesslevels.md) | [Русский](manageaccesslevels.ru.md)

Наименование: **Управлять уровнями доступа**.

Сценарий, отвечающий за управление уровнями доступа менеджером в компании, занимающейся доставкой, включает в себя контроль доступа к определенным областям или системам на основе ролей или обязанностей сотрудников, обеспечение защиты конфиденциальных данных и мониторинг доступа для обеспечения соответствия политикам безопасности.

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
- Администратор выбирает опцию "Уровни доступа".
- Система отображает список сотрудников и их текущие уровни доступа.
- Менеджер выбирает сотрудника и обновляет его уровень доступа.
- Система обновляет уровень доступа сотрудника в базе данных.

![admin.managepermissions](../../img/activitydiagrams/admin.managepermissions.png)
