# authapi

Доступно на других языках: [English/Английский](authapi.md), [Russian/Русский](authapi.ru.md). 

API для аутентификации 

## Требования к сервису и его описание 

Общая модель системы: 

![system_overall](../img/system_overall.png)

Описание API для аутентификации: 
- Часть высоконагруженной системы: каждый элемент системы должен быть способен выдержать нагрузку до 5 тыс. запросов в секунду на запись и чтение.
- Данный сервис производит запись/чтение сессионных токенов в БД и через брокер сообщений уведомляет сервисы, в которых критично наличие токенов, об изменениях в БД, связанных с токенами (например, в число таких сервисов входят [customer backend](customerbackend.ru.md), [kitchen backend](kitchenbackend.ru.md), [courier backend](courierbackend.ru.md), [manager backend](managerbackend.ru.md)).
- К данному сервису могут обращаться все клиентские приложения, приведенные на рисунке выше в разделе "End user applications": [customer](../frontend/customerclient.ru.md), [kitchen](../frontend/kitchenclient.ru.md), [courier](../frontend/courierclient.ru.md), [manager](../frontend/managerclient.ru.md), [admin](../frontend/adminclient.ru.md).
- В качестве брокера сообщений используется RabbitMQ.
- В качестве БД используется PostgreSQL.
- В целях уменьшения риска компрометации персональных данных, сервис не хранит никаких данных, связанных с пользователями: только GUID пользователей, а также таблицы, связанные с аутентификацией ("сессионный токен", "временная регистрация", "подозрительная регистрация").
- На клиентском приложении хранится только таблица "проверка кода".
- Поля сессионного токена (в виде объекта и таблиц в БД):
    - сгенерированный GUID токена, 
    - начало/окончание действия токена, 
    - GUID пользователя (актуально только для таблицы на сервисе).
- Поля временной регистрации: 
    - GUID пользователя, 
    - сгенерированный GUID токена, 
    - начало/окончание действия токена, 
    - код подтверждения регистрации, 
    - время отправки кода подтверждения, 
    - количество попыток ввода кода регистрации, 
    - время отправки запроса на временную регистрацию из клиентского приложения, 
    - устаревшая регистрация, 
    - перезаписанная регистрация,
    - код закрытия регистрации (успех, отказ в предоставлении кода подтверждения, исчерпано количество попыток подтверждения кода, отвалился по таймауту, перезаписан, отмена).
- Поля подозрительной регистрации: повторяет поля временной регистрации.
- Поля проверки кода (актуально только на клиенте потребителя): 
    - GUID токена, 
    - начало/окончание действия токена, 
    - код подтверждения регистрации, 
    - время отправки кода подтверждения, 
    - количество попыток ввода, 
    - устаревший, 
    - перезаписан,
    - код закрытия: возможные значения те же, что и для аналогичного поля временной регистрации.
- Джобы: 
    - Пометка записей в таблице проверки кода регистрации на клиентском приложении как устаревшие и перемещение на сервис (каждые 15-30 минут): если время отправки запроса было раньше продолжительности перепроверки и не закрыта.
    - Копирование подозрительных записей из временной регистрации в таблицу с подозрительной регистрацией (1 раз в сутки): если было N и более не закрытых как успешных.
    - Удаление устаревших записей из проверки кода регистрации на клиентском приложении и временной регистрации на сервисе (1-7 раз в неделю).
- Любой новый вход в приложение обновляет дату окончания действия сессионного токена.

Описание запросов: 
- При GET-запросе от клиентского приложения (на создание нового сессионного токена): получает пустой запрос, генерирует сессионный токен в виде GUID объекта, конвертирует его к строковому значению и записывает в БД, после чего в качестве ответа возвращает объект токена
- При POST-запросе от клиентского приложения (на получение всей информации по сессионному токену в БД): получает запрос с указанием GUID, конвертирует его к строковому значению и проверяет наличие/актуальность такой записи в БД, в случае отсутствия/неактуальности записи генерирует новый GUID, после этого возвращает объект токена

## Пошаговое описание работы клиентского приложения и сервиса 

### Регистрация в приложении 

Регистрация в приложении возможна только для потребителей, а для персонала компании (курьеры, сотрудники кухни, менеджеры, администраторы) - учетная запись заводится вручную главным администратором. 

Последовательность действий:
1. Пользователь открывает приложение и выбирает регистрацию. 
2. Пользователь вводит логин, email, телефон и пароль (пароль вводится дважды).
    - На форме производится валидация введенных значений.
    - Если валидация не проходит, то высвечивается сообщение об ошибке (остаемся на форме и даем пользователю возможность ввести данные ещё раз).
    - Если валидация прошла, то на сервис аутентификации отправляется запрос с JSON объектом (поля: логин, email, телефон, пароль, дата/время) на создание пользователя.
    - Перед созданием пользователя проверяется, существует ли такой пользователь в БД.
    - Если пользователь не существует в БД, то запись пользователя добавляется в БД, затем генерируется токен, добавляется в БД и привязывается к ИД пользователя, после этого сервис возвращает информацию по созданному токену (GUID, дата/время начала и окончания действия токена).
    - Если логин уже существует, то высвечивется сообщение "К сожалению, пользователь с таким именем уже существует. Пожалуйста, попробуйте снова".
    - Если email и/или телефон уже существует в БД, то высвечивается сообщение "Пользователь с таким email и/или номером телефона уже существет. Из соображений безопасности данных, деактивируйте предыдущую учетную запись либо попробуйте вспомнить пароль к предыдущему аккаунту" и выбор "Вспомнить пароль"/"Деактивировать старую запись"/"Отмена".
    - Если пользователь нажимает "Вспомнить пароль", то он перенаправляется в форму входа в приложение.
    - Если пользователь нажимает "Деактивировать старую запись", то активные записи в таблицах пользователей и токенов помечаются как устаревшие и перезаписанными, и создается новый пользователь (список GUID перезаписанных токенов передаются в качестве ответа).
    - Все изменения на данном этапе заносятся в таблицу временной регистрации.
3. На указанный email/номер отправляется код подтверждения регистрации.
    - Код генерируется в приложении, вносится в таблицу временных значений и отправляется по email/СМС.
    - Если во временной таблице несколько незакрытых записей в течение дня с одинаковыми логином/email/телефоном, то вероятно, что пользователя пытаются взломать, поэтому после n-го раза в сообщении должно быть упоминание, что это последний раз за день.
4. Пользователь попадает на страницу ввода кода подтверждения.
    - Отправляется запрос на сервис для получения кода подтверждения.
    - Полученный ответ от сервиса добавляется в БД (пометить переданные токены как перезаписанные).
5. Пользователь вводит код подтверждения.
    - Введенный код сравнивается с кодом подтверждения из сервиса.
    - После каждого сравнения кода суммарное количество использованных попыток увеличивается в БД, находящейся на стороне клиентского приложения.
    - На ввод кода подтверждения дается 3-5 попыток.
    - Если пользователь закрыл приложение, то через какое-то время джоба на клиентском приложении пометит запись как устаревшую и отправит на сервис информацию по коду подтверждения.
    - Если пользователь после закрытия заходит снова в приложение, то он попадает на форму регистрации и повторяет все действия снова (старая попытка должна быть перезаписывана на предыдущем этапе).
    - Если пользователь отменил ввод, то нужно отметить код закрытия в БД и отправить на сервис информацию по подтверждению.
    - Если пользователь не смог подтвердить код за 3-5 попыток, то на сервис отправляется запрос, чтобы пометить запись для пользователя устаревшей и занести количество попыток, и после этого пользователь перенаправляется на форму регистрации.
    - Если пользователь подтвердил код, то запись в таблице временной регистрации отмечается как закрытая.
6. Пользователь вовращается в форму входа в приложение.

### Вход в приложение 

Вход в приложение возможно выполнить любому пользователю: и конечному потребителю, и сотруднику компании.

Последовательность действий:
1. Пользователь открывает приложение и выбирает войти. 
2. Пользователь вводит логин/email/телефон и пароль.
    - На форме производится валидация введенных значений.
    - Если валидация не проходит, то высвечивается сообщение об ошибке (остаемся на форме и даем пользователю возможность ввести данные ещё раз).
    - Если валидация прошла, то на сервис аутентификации отправляется запрос с JSON объектом (поля: логин/email/телефон, пароль, дата/время) на подверждение входа.
    - Если пользователь с указанным логином/email/телефоном не существует в БД, или отличаются пароли, то отображаем сообщение об ошибке "Неверный логин или пароль. Пожалуйста, пробуйте ещё раз".
    - Если логин/email/телефон и пароль введены верно, то пользователь получает сессионный токен.
    - Если при получении сессионного токена выясняется, что он просрочен, то у него просто обновляется дата окончания, и он так же возвращается пользователю.
3. Пользователь попадает в приложение.

## Методы для обработки сетевых запросов на стороне сервиса аутентификации 

Объекты: 
- User credentials: 
    - login, 
    - email, 
    - phone number, 
    - password.
- User existance: 
    - login exists, 
    - email exists, 
    - phone number exists, 
    - exception message.
- Session token:
    - token GUID, 
    - begin/end of token, 
    - activation code, 
    - datetime of code sending, 
    - overriden tokens,
    - exception message.
- Token info: 
    - token GUID, 
    - number of tries, 
    - deprecated, 
    - overriden, 
    - reason to close.
- Get code info response:
    - is successful, 
    - exception message.
- User ID response:
    - is verified, 
    - user ID, 
    - exception message.
- User ID request:
    - user ID.

Методы для регистрации: 
- Check user existance (input: User credentials; output: User existance);
- Add user (input: User credentials; output: Session token);
- Get code info (input: Token info; output: Get code info response).

Методы для входа в приложение:
- Verify user credentials (input: User credentials; output: User ID response);
- Get token by user ID (input: User ID request; output: Session token).