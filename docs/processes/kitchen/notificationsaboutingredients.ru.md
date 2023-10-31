# notificationsaboutingredients

[English](notificationsaboutingredients.md) | [Русский](notificationsaboutingredients.ru.md)

Клиентское приложение для кухни: получать уведомления об ингредиентах.

Сценарий уведомления о доставке ингредиентов в приложении службы доставки предполагает уведомление работников кухни о доставке на кухню необходимых ингредиентов для заказа.
Это позволяет им оперативно приступить к подготовке заказа и гарантирует наличие всех необходимых ингредиентов.

Макропроцесс: [maintenance](../../macroprocesses/maintenance.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/kitchenclient.ru.md), [бэкэнд-сервис](../../backend/kitchenbackend.ru.md)

## Описание процесса

This process is associated with the macroprocess [delivering](../../macroprocesses/delivering.ru.md):

![delivering_overall](../../img/delivering_overall.png)

However, the implementation of this service in the context of user notification is performed as part of the macro process [maintenance](../../macroprocesses/maintenance.md):

![maintenance_overall](../../img/maintenance_overall.png)

### Пошаговое выполнение

- Сотрудник кухни открывает приложение.
- Система проверяет заказ на доставку и определяет необходимые ингредиенты.
- Если ингредиентов нет на кухне, система отправляет уведомление на склад для их доставки.
- Когда ингредиенты доставлены, система отправляет уведомление работнику кухни.
