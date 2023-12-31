# kitchenbackend

[English](kitchenbackend.md) | [Русский](kitchenbackend.ru.md)

`kitchenbackend` — это бэкенд сервис, который управляет подготовкой заказов на еду.

[Бэкэнд-сервис кухни](kitchenbackend.md) в приложении службы доставки отвечает за управление заказами и обеспечение связи между персоналом кухни и сотрудниками склада и курьерами.

Приложение позволяет персоналу кухни получать заказы и управлять ими, обновлять статус заказа, получать в режиме реального времени обновления о наличии продуктов и общаться с курьерами о деталях доставки.
Служба также предоставляет аналитику и отчеты в режиме реального времени, которые помогают оптимизировать работу кухни и повысить эффективность доставки.

[Клиентское приложение](../frontend/kitchenclient.ru.md)

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Заказать оборудование](../processes/systembackend/requestequipment.ru.md)
- [Получать уведомление о доставки ингридиентов](../processes/kitchen/notificationsaboutingredients.ru.md)
- [Доставить со склада на кухню](../flowchartsteps/delivering/wh2kitchen.ru.md)

## Flowchart-шаги

- [Приготовление заказа](../flowchartsteps/delivering/preparemeal.ru.md)
