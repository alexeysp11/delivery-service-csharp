# orders

[English](orders.md) | [Русский](orders.ru.md)

Наименование: **Получение списка заказов**.

Общее описание сценария просмотра истории заказов в серверной службе клиентов заключается в том, что он позволяет клиентам получить доступ к записи своих прошлых заказов, включая такие детали, как дата заказа, заказанные товары, место доставки и общая стоимость.

Интерактивные шаги в сценарии включают выбор вкладки истории заказов, просмотр прошлых заказов и просмотр сведений о заказе.

Паттерн процесса: [information](../../processpatterns/information.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

Версия платформы: v0.1

## Описание процесса

- Отображение информации по предыдущим заказам в виде списка объектов [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs). Таким образом, клиент может просмотреть подробную информацию о каждом заказе, например, заказанные товары, адрес доставки и статус заказа (например, изготовление, доставка).
- Детали заказы также можно наблюдать в разделе [Текущие заказы](../customer/pendingorders.ru.md).
- Загрузка файлов с сервера (отчета по конкретному заказу): 
    - расширения файлов: изображения, PDF.
    - отправка сообщения на эл.почту/Телеграм.
- Пользователь может открыть конкретный заказ, получить превью и выгрузить его в виде файла.
    - Попробовать сделать превью в виде HTML, а потом конвертировать в PDF с помощью [workflow-lib](https://github.com/alexeysp11/workflow-lib).
<!--
- Использование предиктивных моделей: ориентировочное время готовки и доставки.
- Из списка всех заказов возможно перейти в "Дашборды", установить фильтры для выгрузки статистики, получить превью и выгрузить его в виде файла.
- Статистика по предыдущим заказам в виде дашбордов: 
    - по времени: 
        - день, 
        - неделя,
        - месяц,
        - год,
        - всё время; 
    - по типу графиков:
        - Line chart,
        - Bar chart,
        - Histogram,
        - Scatter plot и т.д.; 
    - метрики:
        - общая сумма заказа,
        - стоимость позиции,
        - количество заказов,
        - количество позиций,
        - время оформления заказов,
        - место доставки.
-->

![information_overall](../../img/processpatterns/information_overall.png)

### План пошагового выполнения процесса

- Пользователь открывает страницу "Все заказы".
- Приложение проверяет, доступна ли информация о заказах в базе данных кэша.
- Если информация присутствует и актуальна, приложение отображает заказы покупателю.
- Если информация отсутствует или устарела, приложение перенаправляет запрос в [бэкенд-сервис клиентского приложения](../../backend/customerbackend.ru.md) для получения заказов.

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Структуры данных

| Объект | DTO | Таблица в БД |
| --- | ---- | --- |
| [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs) | - | [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md) |
| [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/ProductCategory.cs) | - | [delivery_category_cb](../../dbtables/customer/delivery_category_cb.md) |
| [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs) | DeliveryOrderDTO | [delivery_order_cb](../../dbtables/customer/delivery_order_cb.md) |

<!--
## Примеры заказа

![purchase-order-template](https://templates.invoicehome.com/purchase-order-template-us-mono-black-750px.png)
-->
