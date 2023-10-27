# customer.makeorder

Доступно на других языках: [English/Английский](makeorder.md), [Russian/Русский](makeorder.ru.md). 

Клиентское приложение для потребителя: оформление заказа.

Связанные модули: [клиентское приложение](../../frontend/customerclient.md), [бэкенд-сервис](../../backend/customerbackend.md).

## Описание процесса

- Основной процесс в приложении [customer app](../../frontend/customerclient.md).
- Ответсвенен за регистрацию заказа в приложении.
- Включает в себя логику электронной оплаты.

![placing_order_overall](../../img/placing_order_overall.png)

### Пошаговое выполнение

- Пользователь просматривает список доступных товаров и выбирает те, которые хочет заказать.
- Пользователь переходит к оформлению заказа и выбирает предпочтительный вариант доставки, вводит адрес доставки и контактные данные? выбирает предпочтительный способ оплаты (наличными, POS при получении, с помощью QR-кода, с помощью CVC), а затем подтверждает заказ.
- Клиентское приложение проверяет дату и сохраняет данные в кэш.
- Начать процесс [makepayment](makepayment.md).
- Затем введенная пользователем информация отправляется в базу данных и в [customerbackend](../../backend/customerbackend.md), который также уведомляет [kitchenbackend](../../backend/kitchenbackend.md) (это происходит в рамках процесса [preprocessorder](preprocessorder.ru.md)).
- Пользователь находится на странице [Текущие заказы](pendingorders.ru.md), где он может отслеживать статус своего заказа в режиме реального времени.

![customer.makeorder](../../img/activitydiagrams/customer.makeorder.png)

## Данные

### Объекты 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)

### DTOs

- [PlaceOrderModel](../../classes/models/Orders/PlaceOrderModel.md)

### Таблицы в БД

- [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md)
- [delivery_category_cb](../../dbtables/customer/delivery_category_cb.md)
- [delivery_order_cb](../../dbtables/customer/delivery_order_cb.md)
- [delivery_placeordermodel_cb](../../dbtables/customer/delivery_placeordermodel_cb.md)
