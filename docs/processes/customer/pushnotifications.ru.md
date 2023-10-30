# pushnotifications

Доступно на других языках: [English/Английский](pushnotifications.md), [Russian/Русский](pushnotifications.ru.md). 

Бэкенд сервис приложения для потребителей: получение пуш-уведомлений.

Сценарий push-уведомлений в приложении службы доставки предполагает отправку уведомлений пользователям в реальном времени через SignalR.

Связанные модули: [клиентское приложение](../../frontend/customerclient.md), [бэкенд-сервис](../../backend/customerbackend.md).

## Описание процесса

- От точки зрения получателя приложение получает и отображает уведомление на его устройстве, предоставляя соответствующую информацию о статусе заказа или других обновлениях.
- С точки зрения отправителя приложение отправляет пользователям уведомления в зависимости от статуса их заказа или других соответствующих обновлений, используя SignalR, чтобы гарантировать доставку уведомлений в режиме реального времени.

### Пошаговое выполнение

- Получение push-уведомлений от POV получателя:
    - Ресивер открывает приложение.
    - Приложение устанавливает соединение с сервером SignalR.
    - Сервер отправляет push-уведомления в приложение.
    - Приложение отображает уведомления пользователю.
- Получение push-уведомлений от точки зрения отправителя:
    - Отправитель открывает приложение.
    - Приложение устанавливает соединение с сервером SignalR.
    - Отправитель отправляет push-уведомление на сервер.
    - Сервер отправляет уведомление получателям, которые подписаны на это событие.