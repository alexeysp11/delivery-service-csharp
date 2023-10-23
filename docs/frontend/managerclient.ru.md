# managerclient

Доступно на других языках: [English/Английский](managerclient.md), [Russian/Русский](managerclient.ru.md). 

`managerclient` - это клиентское приложение, которое используется владельцами бизнеса для доступа к инструментам аналитики и отчетности.

## Общая модель системы

![system_overall](../img/system_overall.png)

### Описание приложения

- Собирает информацию по работе курьеров и поваров (местоположение, загруженность).
- Есть информация о меню.
- Загрузка файлов на сервер и с сервера: 
    - расширения файлов: изображения, Word, Excel, PDF.

Описание **бэкенд-сервиса** для данного приложения представлено по [данной ссылке](../backend/managerbackend.ru.md).

## Аутентификация 

Для аутентификации используется внешний **сервис аутентификации** [workflow-auth](https://github.com/alexeysp11/workflow-auth).

![authentication](../img/authentication.png)

### Вход в приложение

![flowchart-signin](https://github.com/alexeysp11/workflow-auth/raw/main/docs/img/flowchart-signin.png)
