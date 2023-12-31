# changerecipe

[English](changerecipe.md) | [Русский](changerecipe.ru.md)

Наименование: **Изменение рецепта**.

Сценарий изменения состава и ингридиентов блюд в приложении службы доставки включает в себя получение сведений об актуальном составе блюд из базы данных, расчет и изменение необходимых ингредиентов, необходимых для приготовления блюд, и инструкций по приготовлению.
Необходимым условием при изменении состава блюд является установка даты и времени, когда изменения станут актуальными.

Сценарий также включает в себя цепочку согласования изменений (например, *менеджер кухни*, *маркетолог*, *финансовый аналитик*, *генеральный директор*).

В случае успешного согласования приложение обновляет состав блюд и уведомляет остальные микросервисы платформы о произошедших изменениях.

В рамках данного проекта мы исходим из идеи того, что все ингридиенты, необходимые для приготовления блюд, можно бесприпятственно купить в продуктовом магазине. 
Однако в реальном мире возможна ситуация, при которой для некоторых продуктов, будет необходимо изменять цепочки поставок, что в свою очередь может накладываеть ограничения на установку даты и времени, когда изменения составов блюд будут применены. 

Паттерн процесса: [requesting](../../processpatterns/requesting.md)

Ответственные модули: [клиентское приложение](../../frontend/kitchenclient.md), [бэкэнд-сервис](../../backend/kitchenbackend.md)

Версия платформы: v0.1

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.ru.md) | [approval](../manager/approval.ru.md) |
| [adminbackend](../../backend/adminbackend.ru.md) | [dbreplication](../admin/dbreplication.ru.md) |

## Описание процесса

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### План пошагового выполнения процесса

- Сотрудник кухни входит в приложение и переходит в раздел «Управление рецептами».
- Сотрудник выбирает рецепт, который нужно изменить.
- Приложение предоставляет возможности редактирования ингредиентов, количества, инструкций по приготовлению и т. д.
- Сотрудник вносит изменения
- Приложение обновляет базу данных рецептов с учетом изменений.
- Приложение уведомляет соответствующих сотрудников об изменениях.

![kitchen.changemenu](../../img/activitydiagrams/kitchen.changemenu.png)
