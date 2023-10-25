# customerbackend

Доступно на других языках: [English/Английский](customerbackend.md), [Russian/Русский](customerbackend.ru.md). 

`customerbackend` — это бэкенд сервис, который выполняет функции, связанные с клиентами, такие как просмотр продуктов, размещение заказов и управление информацией об учетной записи.

## Общая модель системы

![system_overall](../img/system_overall.png)

Описание **клиентского приложения** представлено по [данной ссылке](../../frontend/frontend/customerclient.ru.md). 
Понимание того, как будет использоваться клиентское приложение, позволяет сформировать требования к его основному бэкенд-сервису. 

## Описание бэкенда приложения для потребителей

- При запросах от клиентского приложения, проверяет сессионный токен.
- Выгрузка информации для отчетов по заказам: список всех заказов, информация по конкретному заказу (фактическое время оформления, готовки и доставки; ориентировочное время готовки и доставки, общая сумма заказа, стоимость позиций заказа, место доставки; статус).
- Интеграция с сервисами оплаты (по видам оплаты, указанным ранее).
<!--
- Слушает очередь сообщений, в которую записываются сообщения об изменениях в пользователях и токенах, хранящихся модулем [authentication API](authbackend.ru.md).
- Записывает в очередь сообщений информацию об изменениях в пользователях и токенах (очередь слушает модуль [authentication API](authbackend.ru.md)).

## Методы для обработки сетевых запросов 

- **Get all user orders** - получение всех заказов пользователя (наименование: `GetAllOrders`): 
    - input: ;
    - output: `UserOrders`.

### JSON объекты для межсетевого взаимодействия 

- **User orders** - информация по заказам пользователя (наименование: `UserOrders`): 
    - temp.
    - `DeliveryOrders: List<DeliveryOrder>` - заказы пользователя,
    - Exception.
-->

## Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)

## Таблицы в БД

- [delivery_customer](../dbtables/delivery_customer.md)
- [delivery_customer_tmp](../dbtables/delivery_customer_tmp.md)
- [delivery_customer_token](../dbtables/delivery_customer_token.md)
- [delivery_customer_category](../dbtables/delivery_customer_category.md)
- [delivery_customer_menuitem](../dbtables/delivery_customer_menuitem.md)
