# signup

[English](signup.md) | [Русский](signup.ru.md)

Клиентское приложение: регистрация в приложении.

Сценарий регистрации в клиентском приложении предполагает, что пользователь создает новую учетную запись, предоставляя свою личную информацию, такую как логин, адрес электронной почты и пароль.

Ответственные модули: [бэкенд-сервис](../../backend/authbackend.md).

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### Пошаговое выполнение 

- Пользователь открывает клиентское приложение.
- Пользователь нажимает кнопку "Зарегистрироваться".
- Пользователь вводит свою личную информацию, такую как имя, адрес электронной почты и пароль.
- Приложение проверяет информацию пользователя и проверяет, зарегистрирован ли уже адрес электронной почты.
- Если информация действительна и адрес электронной почты еще не зарегистрирован, приложение создает для пользователя новую учетную запись и предоставляет ему доступ к функциям и функциям приложения.
- Если есть какие-либо ошибки или проблемы с информацией пользователя, приложение отображает сообщение об ошибке и предлагает пользователю исправить свою информацию, прежде чем продолжить.

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Данные

### Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/Customers/Customer.md)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/InformationSystem/UserAccount.md)

### DTOs

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/SignUpModel.md)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCreationResult.md)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSURequest.md)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VSUResponse.md)

### Таблицы в БД

- [delivery_customer_cb](../../dbtables/customer/delivery_customer_cb.md)
