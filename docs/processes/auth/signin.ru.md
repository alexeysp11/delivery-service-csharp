# signin

[English](signin.md) | [Русский](signin.ru.md)

Наименование: **Вход в приложение**.

Сценарий входа в клиентское приложение предполагает, что пользователь вводит свой логин и пароль для доступа к своей учетной записи и размещения заказов на доставку.

Ответственные модули: [бэкенд-сервис](../../backend/authbackend.md).

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [workflow-auth](https://github.com/alexeysp11/workflow-auth) | |

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

## Структуры данных

### Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs)

### DTOs

- [SignInModel](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SignInModel.cs)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCredentials.cs)
- [VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VUCResponse.cs)
- [SessionToken](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SessionToken.cs)
- [TokenRequest](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/TokenRequest.cs)

### Таблицы в БД

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
