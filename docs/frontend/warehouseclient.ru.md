# warehouseclient

Доступно на других языках: [English/Английский](warehouseclient.md), [Russian/Русский](warehouseclient.ru.md). 

`warehouseclient` - это клиентское приложение, которое используется сотрудниками склада для управления запасами и выполнения заказов.

## Требования к системе и её описание 

### Общая модель системы 

![system_overall](../img/system_overall.png)

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Вход в приложение

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
