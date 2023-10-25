# customer.makeorder

Доступно на других языках: [English/Английский](makeorder.md), [Russian/Русский](makeorder.ru.md). 

Клиентское приложение для потребителя: оформление заказа.

Описание **клиентского приложения** представлено по [данной ссылке](../../frontend/customerclient.ru.md).

![placing_order_overall](../../img/placing_order_overall.png)

### Пошаговое выполнение

- Пользователь просматривает список доступных товаров и выбирает те, которые хочет заказать.
- Пользователь переходит к оформлению заказа и выбирает предпочтительный вариант доставки, вводит адрес доставки и контактные данные? выбирает предпочтительный способ оплаты (наличными, POS при получении, с помощью QR-кода, с помощью CVC), а затем подтверждает заказ.
- Клиентское приложение проверяет дату и сохраняет данные в кэш.
- Затем введенная пользователем информация отправляется в базу данных и в [customerbackend](../../backend/customerbackend.md), который также уведомляет [kitchenbackend](../../backend/kitchenbackend.md) (это происходит в рамках процесса [preprocessorder](preprocessorder.ru.md)).
- Пользователь находится на странице [Текущие заказы](pendingorders.ru.md), где он может отслеживать статус своего заказа в режиме реального времени.

![customer.makeorder](../../img/activitydiagrams/customer.makeorder.png)

## Объекты 

- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [ProductCategory](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/ProductCategory.md)
- [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)
- [PlaceOrderModel](../../classes/models/Orders/PlaceOrderModel.md)
