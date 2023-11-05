# settings

[English](settings.md) | [Русский](settings.ru.md)

Наименование: **Настройки**.

Сценарий личных настроек в клиентском приложении предполагает предоставление пользователям возможности просматривать и редактировать свою личную информацию, такую как имя, адрес электронной почты и способы оплаты.
Приложение надежно хранит эту информацию и позволяет пользователям обновлять ее по мере необходимости.

Макропроцесс: [information](../../macroprocesses/information.md)

Ответственные модули: [клиентское приложение](../../frontend/customerclient.ru.md), [бэкенд-сервис](../../backend/customerbackend.ru.md)

## Описание процесса

Страница настроек и персональных данных: 
- Персональная информация:
   - логин (сохранён в [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), см. [useraccount](../systembackend/useraccount.ru.md)),
   - email (сохранён в [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), см. [useraccount](../systembackend/useraccount.ru.md)),
   - телефон (сохранён в [ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal), см. [useraccount](../systembackend/useraccount.ru.md)),
   - подключенные мессенджеры: WhatsApp, Viber, Telegram,
   - никнейм в Telegram,
   - предпочитаемый способ связи: эл.почта, телефон, один из мессенджеров,
- Оплата:
   - предпочитаемый вид оплаты,
   - привязанные карты.
- Юзабилити:
   - место доставки по умолчанию.
- Безопасность:
   - пароль (этот параметр пустой по умолчанию).

Можно также перейти в [аккаунт пользователя](../systembackend/useraccount.ru.md), чтобы ознакомиться с некоторыми персональными настройками.

![information_overall](../../img/information_overall.png)

### Пошаговое выполнение

- Пользователь открывает "Настройки".
- Некоторые параметры загружаются со страницы [аккаунт пользователя](../systembackend/useraccount.ru.md), а некоторые параметры загружаются из базы данных или [бэкенд-сервиса](../../backend/customerbackend.ru.md).
- Пользователь изменяет настройки.
- Внизу страницы есть кнопка "Сохранить изменения".
    - Изменения попадают на сервисы, после ответа от сервиса - в БД.
    - После этого отображаются у пользователя на интерфейсе: "Успешно" или "Произошла ошибка".

![customer.settings](../../img/activitydiagrams/customer.settings.png)
