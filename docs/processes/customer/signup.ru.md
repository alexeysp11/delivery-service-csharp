# customer.signup

Доступно на других языках: [English/Английский](signup.md), [Russian/Русский](signup.ru.md). 

Клиентское приложение для потребителя: регистрация в приложении 

Связанные модули: [клиентское приложение](../../frontend/customerclient.md), [бэкенд-сервис](../../backend/customerbackend.md).

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### Пошаговое выполнение 

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

## DTOs

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignUpModel.md)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCreationResult.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSURequest.md)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSUResponse.md)

## Таблицы в БД

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
