# useraccount

[English](useraccount.md) | [Русский](useraccount.ru.md)

Клиентское приложение для потребителя: аккаунт пользователя.

Ответственные модули: [клиентское приложение](../../frontend/customerclient.md).

## Описание процесса

- Контроллер обрабатывает запрос и сохраняет на UI необходимые для отображения данные о пользователе.
- Как такового пошагового описания для данного процесса не подразумевается, т.к. необходимые данные о пользователе были получены ещё при аутентификации и сохранены в [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal) как [ClaimTypes](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimtypes) (см. процесс [signin](signin.md)).
- Отображаются следующие поля: 
    - логин,
    - эл. почта,
    - телефон.
