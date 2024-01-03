# signup

[English](signup.md) | [Русский](signup.ru.md)

Наименование: **Регистрация в приложении**.

Сценарий регистрации в клиентском приложении предполагает, что пользователь создает новую учетную запись, предоставляя свою личную информацию, такую как логин, адрес электронной почты и пароль.

Ответственные модули: [бэкенд-сервис](../../backend/authbackend.md).

Версия платформы: v0.1

## Описание процесса

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../../img/authentication.png)

### План пошагового выполнения процесса 

- Пользователь открывает клиентское приложение.
- Пользователь нажимает кнопку "Зарегистрироваться".
- Пользователь вводит свою личную информацию, такую как имя, адрес электронной почты и пароль.
- Приложение проверяет информацию пользователя и проверяет, зарегистрирован ли уже адрес электронной почты.
- Если информация действительна и адрес электронной почты еще не зарегистрирован, приложение создает для пользователя новую учетную запись и предоставляет ему доступ к функциям и функциям приложения.
- Если есть какие-либо ошибки или проблемы с информацией пользователя, приложение отображает сообщение об ошибке и предлагает пользователю исправить свою информацию, прежде чем продолжить.

![flowchart-signup](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signup.png)

## Структуры данных

### Объекты 

- [Customer](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Customers/Customer.cs)
- [UserAccount](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/InformationSystem/UserAccount.cs)

### DTOs

- [SignUpModel](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/SignUpModel.cs)
- [UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCreationResult.cs)
- [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCredentials.cs)
- [VSURequest](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VSURequest.cs)
- [VSUResponse](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VSUResponse.cs)
