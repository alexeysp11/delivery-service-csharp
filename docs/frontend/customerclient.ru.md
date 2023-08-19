# customerclient

Доступно на других языках: [English/Английский](customerclient.md), [Russian/Русский](customerclient.ru.md). 

Клиентское приложения для потребителей 

## Требования к системе и её описание 

Общая модель системы: 

![system_overall](../img/system_overall.png)

Описание приложения для потребителей: 
- Часть высоконагруженной системы: каждый элемент системы должен быть способен выдержать нагрузку до 5 тыс. запросов в секунду на запись и чтение.
- Интегрируется напрямую с [authentication API](../backend/authapi.ru.md), [customer backend](../backend/customerbackend.ru.md), [file service](../backend/fileservice.ru.md), [statistical model](../backend/statisticalmodel.ru.md), [predictive model](../backend/predictivemodel.ru.md), [email sender](../backend/emailsender.ru.md), [push notifications](../backend/pushnotifications.ru.md).
- [Оформление заказа](processes/customer.makeorder.ru.md).
- [Все заказы](processes/customer.orders.ru.md): отображение информации/статистики по предыдущим заказам в виде списков и дашбордов.
- [Текущие заказы](processes/customer.pendingorders.ru.md): отслеживание статуса заказа.
- [Настройки](processes/customer.settings.ru.md).
- Получение пуш-уведомлений.
- Просмотр видео.
- Виды оплаты:
    - наличная при получении, 
    - через валидатор при получении, 
    - через приложение банка по QR-коду,
    - в приложении с помощью CVC.

Описание бэкенд-сервиса для данного приложения представлено по [данной ссылке](../backend/customerbackend.ru.md).
