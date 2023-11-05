# signin

[English](signin.md) | [Русский](signin.ru.md)

Наименование: **вход в приложение**.

Сценарий входа в клиентское приложение предполагает, что пользователь вводит свой логин и пароль для доступа к своей учетной записи и размещения заказов на доставку.

Ответственные модули: [бэкенд-сервис](../../backend/authbackend.md).

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### Пошаговое выполнение 

- Пользователь открывает клиентское приложение.
- Пользователь нажимает кнопку "Войти".
- Пользователь вводит логин и пароль
- Приложение проверяет учетные данные пользователя
- Если учетные данные действительны, приложение предоставляет пользователю доступ к его учетной записи и отображает историю его заказов и другую соответствующую информацию.
- Если учетные данные недействительны, приложение отображает сообщение об ошибке и предлагает пользователю повторить попытку или сбросить пароль.

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)

## Данные

### Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

### DTOs

- [SignInModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignInModel.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VUCResponse.md)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SessionToken.md)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/TokenRequest.md)

### Таблицы в БД

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
