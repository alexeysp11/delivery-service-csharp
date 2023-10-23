# adminclient

Доступно на других языках: [English/Английский](adminclient.md), [Russian/Русский](adminclient.ru.md). 

`adminclient` - это клиентское приложение, которое используется администраторами для управления пользователями, продуктами и заказами на платформе.

## Требования к системе и её описание 

### Общая модель системы 

![system_overall](../img/system_overall.png)

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Вход в приложение

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
