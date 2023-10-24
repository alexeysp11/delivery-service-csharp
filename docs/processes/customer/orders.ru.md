# customer.orders

Доступно на других языках: [English/Английский](orders.md), [Russian/Русский](orders.ru.md). 

Клиентское приложение для потребителя: оформление заказа.

Описание **клиентского приложения** представлено по [данной ссылке](../../frontend/customerclient.ru.md).

## Описание процесса

- Отображение информации по предыдущим заказам в виде списка объектов [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md).
- Отслеживание статуса заказа (изготовление, доставка) 
    - также можно наблюдать в разделе [Текущие заказы](pendingorders.ru.md).
- Загрузка файлов с сервера (отчета по конкретному заказу): 
    - расширения файлов: изображения, PDF.
    - отправка сообщения на эл.почту/Телеграм.
    - Попробовать сделать превью в виде HTML, а потом конвертировать в PDF с помощью [workflow-lib](https://github.com/alexeysp11/workflow-lib).
<!--
- Использование предиктивных моделей: ориентировочное время готовки и доставки.
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

### Пошаговое выполнение

- Пользователь открывает страницу "Все заказы".
- Пользователь может открыть конкретный заказ, получить превью и выгрузить его в виде файла.
- Из списка всех заказов возможно перейти в "Дашборды", установить фильтры для выгрузки статистики, получить превью и выгрузить его в виде файла.

![customer.allorders](../../img/activitydiagrams/customer.allorders.png)

## Объекты 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)

## Примеры заказа

![purchase-order-template](https://templates.invoicehome.com/purchase-order-template-us-mono-black-750px.png)
