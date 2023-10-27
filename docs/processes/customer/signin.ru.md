# customer.signin

Доступно на других языках: [English/Английский](signin.md), [Russian/Русский](signin.ru.md). 

Клиентское приложение для потребителя: вход в приложение 

Связанные модули: [клиентское приложение](../../frontend/customerclient.md), [бэкенд-сервис](../../backend/customerbackend.md).

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### Пошаговое выполнение 

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

## DTOs

- [SignInModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignInModel.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VUCResponse.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/TokenRequest.md)

## Таблицы в БД

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
