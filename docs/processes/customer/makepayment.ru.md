# makepayment

[English](makepayment.md) | [Русский](makepayment.ru.md)

Наименование: **Совершение оплаты**.

Сценарий оплаты в приложении службы доставки предполагает, что пользователь выбирает способ оплаты и предоставляет свою платежную информацию для завершения транзакции по своему заказу.
Приложение безопасно обрабатывает платеж и предоставляет подтверждение успешной транзакции.

Паттерн процесса: [delivering](../../processpatterns/delivering.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [customerbackend](../../backend/customerbackend.ru.md) | [makeorder](../customer/makeorder.ru.md) |
| [courierbackend](../../backend/courierbackend.ru.md) | [deliverorder](../courier/deliverorder.ru.md) |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [fileservice](../../backend/fileservice.ru.md) | [generateqr](../customer/generateqr.ru.md) |

## Описание процесса

- [Приложение для клиентов](../../frontend/customerclient.md) позволяет пользователям осуществлять оплату своих заказов, используя различные способы оплаты.
- Ответственен за осуществление оплаты за заказ.
- Вызывается в рамках процесса [makeorder](../customer/makeorder.ru.md) либо после [deliverorder](../courier/deliverorder.ru.md).

![delivering_overall](../../img/processpatterns/delivering_overall.png)

### Пошаговое выполнение

- Когда клиент размещает заказ, ему необходимо выбрать предпочтительный способ оплаты (см. [makeorder](../customer/makeorder.ru.md)).
- Если они выбирают **наложенный платеж**, они подтверждают заказ и платят курьеру при получении заказа.
- Если они выберут **POS при получении**, они подтвердят заказ и оплатят его кредитной или дебетовой картой при получении заказа.
- Если они выберут **использование QR-кода**, они сканируют QR-код, предоставленный приложением, и подтвердят платеж.
    - [бэкенд-сервис для потребителя](../../backend/customerbackend.md) отправляет запрос в [fileservice](../../backend/fileservice.md) для создания QR-кода для оплаты.
- Если они выберут **использование CVC**, они введут данные своей карты и подтвердят платеж.
    - Добавьте способ оплаты после заполнения формы, если в качестве типа оплаты выбрана карта.
- Приложение подтверждает платеж и отправляет его на бэкенд сервис.

![customer.makepayment](../../img/activitydiagrams/customer.makepayment.png)

## Структуры данных

### Объекты 

- [Payment](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Monetary/Payment.cs)
