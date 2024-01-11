# projectstructure

[English](projectstructure.md) | [Русский](projectstructure.ru.md)

Данный файл описывает структуру проекта в общем виде (продуктовые приложения: клиентские приложения, бэкэнд-сервисы; инфраструктурные бэкэнд-сервисы), а также перечисляет функционал, который относится к каждому приложению.

## Продуктовые приложения

### Клиентские приложения

- функционал, который нужен для оформления заказа на клиентском приложении **потребителя**.
    - оформить заказ (UI: &check;; controller: &cross;; BL: &cross;).
    - оплатить заказ (UI: &cross;; controller: &cross;; BL: &cross;).
    - отображение списка заказов (UI: &cross;; controller: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на клиентском приложении **курьера**.
    - выполнить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &cross;).
    - выполнить доставку заказа потребителю (UI: &cross;; controller: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на клиентском приложении **кухни**.
    - приготовить заказ (UI: &cross;; controller: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на клиентском приложении **склада**.
    - запросить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &cross;).
    - подтвердить доставку из магазина на склад (UI: &cross;; controller: &cross;; BL: &cross;).
    - выполнить доставку со склада на кухню (UI: &cross;; controller: &cross;; BL: &cross;).
    - выполнить доставку с кухни на склад (UI: &cross;; controller: &cross;; BL: &cross;).

### Бэкэнд-сервисы

- функционал, который нужен для обработки заказа на бэкэнд-сервисе **потребителя**.
    - оформить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - оплатить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - отображение списка заказов (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **курьера**.
    - выполнить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - выполнить доставку заказа потребителю (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **кухни**.
    - приготовить заказ (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
- функционал, который нужен для обработки заказа на бэкэнд-сервисе **склада**.
    - запросить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - подтвердить доставку из магазина на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - выполнить доставку со склада на кухню (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).
    - выполнить доставку с кухни на склад (controller WebAPI: &cross;; controller gRPC: &cross;; BL: &cross;).

## Инфраструктурные бэкэнд-сервисы

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
        - courier
        - customer
            - bl
            - blazor
            - mvc
            - wpf
    - backend
        - customer
            - bl
            - mvc
        - fileservice
        - pushnotifications
    - telegrambot
    - core
    - models
- tests
    - frontend
        - customerclientbl
    - backend
        - customerbackendbl
```

