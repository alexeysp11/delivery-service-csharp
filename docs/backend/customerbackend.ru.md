# customerbackend

Доступно на других языках: [English/Английский](customerbackend.md), [Russian/Русский](customerbackend.ru.md). 

`customerbackend` - это бэкенд сервис приложения для потребителей.

## Требования к системе и её описание 

### Общая модель системы

![system_overall](../img/system_overall.png)

Описание клиентского приложения представлено по [данной ссылке](../frontend/customerclient.ru.md). 
Понимание того, как будет использоваться клиентское приложение, позволяет сформировать требования к его основному бэкенд-сервису. 

### Описание бэкенда приложения для потребителей

- При запросах от клиентского приложения, проверяет сессионный токен.
- Выгрузка информации для отчетов по заказам: список всех заказов, информация по конкретному заказу (фактическое время оформления, готовки и доставки; ориентировочное время готовки и доставки, общая сумма заказа, стоимость позиций заказа, место доставки; статус).
- Интеграция с сервисами оплаты (по видам оплаты, указанным ранее).
<!--
- Слушает очередь сообщений, в которую записываются сообщения об изменениях в пользователях и токенах, хранящихся модулем [authentication API](authbackend.ru.md).
- Записывает в очередь сообщений информацию об изменениях в пользователях и токенах (очередь слушает модуль [authentication API](authbackend.ru.md)).
-->

## Таблицы в БД

- **Customer** - потребитель (наименование: `delivery_customer`):
    - `delivery_customer_id: integer` - ИД потребителя,
    - `customer_uid: varchar` - GUID потребителя,
    - `login: varchar` - логин,
    - `email: varchar` - email,
    - `phone_number: varchar` - телефон,
    - `password: varchar` - хэшированный пароль.
- **Temporary customer** - временная таблица потребителя, используется только при регистрации нового пользователя (наименование: `delivery_temp_customer`):
    - `delivery_temp_customer_id: integer` - ИД потребителя,
    - `customer_uid: varchar` - GUID потребителя,
    - `login: varchar` - логин,
    - `email: varchar` - email,
    - `phone_number: varchar` - телефон,
    - `password: varchar` - хэшированный пароль.
- **Customer token** - сессионный токен потребителя (наименование: `delivery_customer_token`):
    - `delivery_customer_token_id: integer` - ИД токена потребителя,
    - `token_guid: varchar` - сгенерированный GUID токена,
    - `token_begin_dt: timestamp` - начало действия токена,
    - `token_end_dt: timestamp` - окончание действия токена,
    - `customer_id: integer` - ИД потребителя.
- **Category** - категория продукта в меню (наименование: `delivery_category`):
    - `delivery_category_id: integer` - ИД категории,
    - `name: varchar` - наименование,
    - `description: varchar` - описание,
    - `picture: bytea` - изображение.
- **Menu item** - элемент меню, продукт (наименование: `delivery_menuitem`)
    - `delivery_menuitem_id: integer` - ИД продукта,
    - `name: varchar` - наименование,
    - `price: double precision` - цена,
    - `description: varchar` - описание,
    - `delivery_category_id: integer` - ИД категории,
    - `picture: bytea` - изображение.
