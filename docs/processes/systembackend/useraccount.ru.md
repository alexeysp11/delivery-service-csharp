# useraccount

[English](useraccount.md) | [Русский](useraccount.ru.md)

Наименование: **Аккаунт пользователя**.

Паттерн процесса: [information](../../processpatterns/information.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md)

## Описание процесса

- Контроллер обрабатывает запрос и сохраняет на UI необходимые для отображения данные о пользователе.
- Как такового пошагового описания для данного процесса не подразумевается, т.к. необходимые данные о пользователе были получены ещё при аутентификации и сохранены в [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal) как [ClaimTypes](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimtypes) (см. процесс [signin](../customer/signin.md)).
- Отображаются следующие поля: 
    - логин,
    - эл. почта,
    - телефон.
- Некоторые поля также отображаются на странице [настройки](../customer/settings.ru.md).

![information_overall](../../img/information_overall.png)

## Структуры данных 

### Объекты 

- [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal)
