# customerbackend.preprocessorder

Доступно на других языках: [English/Английский](preprocessorder.md), [Russian/Русский](preprocessorder.ru.md). 

Бэкенд сервис приложения для потребителей: предварительная обработка заказа.

Описание бэкенд сервиса представлено по [данной ссылке](../../frontend/customerbackend.ru.md).

## Описание процесса

- [Приложение службы доставки](../../../README.ru.md) включает сценарий, который предварительно обрабатывает заказ перед его отправкой на кухню для приготовления.
- Выполняется автоматически в рамках процесса [makeorder](makeorder.ru.md).
- Задействованые бэкенд-сервисы: [customerbackend](../../backend/customerbackend.ru.md) и [warehousebackend](../../backend/warehousebackend.ru.md).
- В БД есть таблицы [delivery_customer_recipe](../../dbtables/delivery_customer_recipe.md), [delivery_customer_ingredient](../../dbtables/delivery_customer_ingredient.md) и [delivery_customer_product](../../dbtables/delivery_customer_product.md), которая содержит рецепты каждого продукта с указанием необходимых исходных продуктов и их количеством/весом/объемом. Рецепты необходимы для того, чтобы на их основе можно было получить количество исходных продуктов, необходимых для выполнения заказа.
    - Данные из этих таблиц попадают из БД, относящейся к сервису [managerbackend](../../backend/managerbackend.ru.md), с помощью механизма репликации
- В БД есть таблица [delivery_wh_whproduct](../../dbtables/delivery_wh_whproduct.md), в которой хранятся данные по продуктам на складе в текущий момент времени.

![placing_order_overall](../../img/placing_order_overall.png)

### Пошаговое выполнение

- Сервис получает запрос, включающий параметры заказа, которые сформированы клиентом (заказ представлен в виде объекта [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/BusinessDocuments/DeliveryOrder.md)).
- В БД выполняется запрос на получение реального количества необходимых исходных продуктов на складе.
- Если **количества** на складе **не достаточно**, то асинхронно запускается процесс [Доставить из магазина на склад](../courier/store2wh.ru.md), и отправляется ответ на сервис, который вызвал данный процесс.
- Если **количества** на складе **достаточно**, то асинхронно запускается процесс [Доставить со склада на кухню](../warehouse/fromwhtokitchen.ru.md), и отправляется ответ на сервис, который вызвал данный процесс.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)

## Objects 

- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/Employee.md)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Ingredient.md)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Product.md)
- [Recipe](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/Recipe.md)
- [WHProduct](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Products/WHProduct.md)

## Database tables 

- [delivery_customer_ingredient](../../dbtables/delivery_customer_ingredient.md)
- [delivery_customer_product](../../dbtables/delivery_customer_product.md)
- [delivery_customer_recipe](../../dbtables/delivery_customer_recipe.md)
- [delivery_wh_whproduct](../../dbtables/delivery_wh_whproduct.md)
