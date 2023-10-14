# customer.signup

Доступно на других языках: [English/Английский](customer.signup.md), [Russian/Русский](customer.signup.ru.md). 

Клиентское приложение для потребителя: регистрация в приложении 

Описание **клиентского приложения** представлено по [данной ссылке](../customerclient.ru.md).

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### Пошаговое описание 

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Объекты

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignUpModel.md)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCreationResult.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSURequest.md)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSUResponse.md)
