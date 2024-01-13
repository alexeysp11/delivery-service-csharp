# projectstructure

[English](projectstructure.md) | [Русский](projectstructure.ru.md)

Данный файл описывает структуру проекта в общем виде (продуктовые приложения: клиентские приложения, бэкэнд-сервисы; инфраструктурные бэкэнд-сервисы), а также перечисляет функционал, который относится к каждому приложению.

## Оформление и обработка заказа на доставку

### Продуктовые приложения

#### Клиентские приложения

- функционал, который нужен для оформления заказа на клиентском приложении **потребителя**.
    - отображение списка заказов (UI: &cross;; controller: &cross;; BL: &cross;).
    - оформить заказ (UI: &check;; controller: &cross;; BL: &check;).
    - оплатить заказ (UI: &cross;; controller: &cross;; BL: &check;).
- функционал, который нужен для обработки заказа на клиентском приложении **курьера**.
    - отображение списка заказов на доставку (UI: &cross;; controller: &cross;; BL: &cross;).
    - выполнить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &check;).
    - выполнить доставку заказа потребителю (UI: &cross;; controller: &cross;; BL: &check;).
- функционал, который нужен для обработки заказа на клиентском приложении **кухни**.
    - отображение списка заказов, которые необходимо приготовить (UI: &cross;; controller: &cross;; BL: &cross;).
    - приготовить заказ (UI: &cross;; controller: &cross;; BL: &check;).
- функционал, который нужен для обработки заказа на клиентском приложении **склада**.
    - отображение списка заказов доставку из магазина на склад, которые необходимо запросить (UI: &cross;; controller: &cross;; BL: &cross;).
    - отображение списка заказов доставку из магазина на склад, которые необходимо подтвердить (UI: &cross;; controller: &cross;; BL: &cross;).
    - отображение списка заказов доставку со склад на кухню (UI: &cross;; controller: &cross;; BL: &cross;).
    - отображение списка заказов доставку с кухни на склад (UI: &cross;; controller: &cross;; BL: &cross;).
    - запросить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &check;).
    - подтвердить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &check;).
    - выполнить доставку со склада на кухню (UI: &cross;; controller: &cross;; BL: &check;).
    - выполнить доставку с кухни на склад (UI: &cross;; controller: &cross;; BL: &check;).

#### Бэкэнд-сервисы

- функционал, который нужен для обработки заказа на бэкэнд-сервисе **потребителя**.
    - оформить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - оплатить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - отображение списка заказов (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **курьера**.
    - выполнить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - выполнить доставку заказа потребителю (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **кухни**.
    - приготовить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **склада**.
    - запросить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - подтвердить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - выполнить доставку со склада на кухню (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).
    - выполнить доставку с кухни на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &check;).

### Инфраструктурные бэкэнд-сервисы

- функционал, который нужен для обработки заказа на бэкэнд-сервисе для файлов.
    - получить файл.
- функционал, который нужен для обработки заказа на бэкэнд-сервисе для уведомлений.
    - отправить уведомление пользователю. 

## См. также

Структура проекта может быть следующей:

```
- data
- dbinit
- docs
- examples
- src
    - authentication
    - frontend
        ...
        - customer
            - bl
            - blazor
            - mvc
            - wpf
        ...
    - backend
        ...
        - customer
            - bl
            - grpc
            - webapi
        ...
        - fileservice
        - notifications
        ...
    - telegrambot
    - core
    - models
- tests
    - frontend
        - customerclientbl
    - backend
        - customerbackendbl
```

