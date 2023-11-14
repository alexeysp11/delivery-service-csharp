# preprocessorder

[English](preprocessorder.md) | [Русский](preprocessorder.ru.md)

Наименование: **Предварительная обработка заказа**.

Сценарий предобработки заказа в приложении службы доставки предполагает получение рецептов из базы данных, расчет необходимого и фактического количества ингредиентов, асинхронный вызов процессов доставки ингредиентов на кухню или продукции из магазина на склад.
На основе этих расчетов приложение определяет примерное время доставки заказа.

Паттерн процесса: [delivering](../../processpatterns/delivering.ru.md)

Ответственные модули: [бэкэнд-сервис](../../backend/customerbackend.md)

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [customerbackend](../../backend/customerbackend.ru.md) | [makeorder](../customer/makeorder.ru.md) |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [warehousebackend](../../backend/warehousebackend.ru.md) | [wh2kitchen](../warehouse/wh2kitchen.ru.md) |
| [warehousebackend](../../backend/warehousebackend.ru.md) | [kitchen2wh](../warehouse/kitchen2wh.ru.md) |
| [kitchenbackend](../../backend/kitchenbackend.ru.md) | [preparemeal](../kitchen/preparemeal.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [store2wh](../courier/store2wh.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [deliverorder](../courier/deliverorder.ru.md) |

## Описание процесса

- [Приложение службы доставки](../../../README.ru.md) включает сценарий, который предварительно обрабатывает заказ перед его отправкой на кухню для приготовления.
- Выполняется автоматически в рамках процесса [makeorder](../customer/makeorder.ru.md).
- Задействованые бэкенд-сервисы: [customerbackend](../../backend/customerbackend.ru.md), [warehousebackend](../../backend/warehousebackend.ru.md), [kitchenbackend](../../backend/kitchenbackend.ru.md), [courierbackend](../../backend/courierbackend.ru.md).
- В БД есть таблицы [delivery_recipe_cb](../../dbtables/customer/delivery_recipe_cb.md), [delivery_ingredient_cb](../../dbtables/customer/delivery_ingredient_cb.md) и [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md), которая содержит рецепты каждого продукта с указанием необходимых исходных продуктов и их количеством/весом/объемом. Рецепты необходимы для того, чтобы на их основе можно было получить количество исходных продуктов, необходимых для выполнения заказа.
    - Данные из этих таблиц попадают из БД, относящейся к сервису [managerbackend](../../backend/managerbackend.ru.md), с помощью механизма репликации.
- В БД есть таблица [delivery_whproduct_whb](../../dbtables/warehouse/customer/delivery_whproduct_whb.md), в которой хранятся данные по продуктам на складе в текущий момент времени.

![delivering_overall](../../img/delivering_overall.png)

### Пошаговое выполнение

- Сервис получает запрос, включающий параметры заказа, которые сформированы клиентом (заказ представлен в виде объекта [DeliveryOrder](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/BusinessDocuments/DeliveryOrder.cs)).
- В БД выполняется запрос на получение реального количества необходимых исходных продуктов на складе.
- Если **количества** на складе **не достаточно**, то асинхронно запускается процесс [Доставить из магазина на склад](../courier/store2wh.ru.md), и отправляется ответ на сервис, который вызвал данный процесс.
- Если **количества** на складе **достаточно**, то асинхронно запускается процесс [Доставить со склада на кухню](../warehouse/wh2kitchen.ru.md), и отправляется ответ на сервис, который вызвал данный процесс.

![customer.preprocessorder](../../img/activitydiagrams/customer.preprocessorder.png)

## Данные

### Объекты 

- [Employee](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/Employee.cs)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs)
- [Ingredient](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Ingredient.cs)
- [Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs)
- [Recipe](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Recipe.cs)
- [WHProduct](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/WHProduct.cs)

### Таблицы в БД

- [delivery_employee_whb](../../dbtables/warehouse/delivery_employee_whb.md)
- [delivery_useraccount_whb](../../dbtables/warehouse/delivery_useraccount_whb.md)
- [delivery_ingredient_cb](../../dbtables/customer/delivery_ingredient_cb.md)
- [delivery_menuitem_cb](../../dbtables/customer/delivery_menuitem_cb.md)
- [delivery_recipe_cb](../../dbtables/customer/delivery_recipe_cb.md)
- [delivery_whproduct_whb](../../dbtables/warehouse/customer/delivery_whproduct_whb.md)
