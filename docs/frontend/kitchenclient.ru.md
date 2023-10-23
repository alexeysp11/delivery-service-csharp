# kitchenclient

Доступно на других языках: [English/Английский](kitchenclient.md), [Russian/Русский](kitchenclient.ru.md). 

`kitchenclient` — это клиентское приложение, которое используется персоналом ресторана для управления приготовлением еды и выполнением заказов.

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Вход в приложение

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
