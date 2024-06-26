# delivery-service-csharp 

[English](README.md) | [Русский](README.ru.md)

**Приложение сервиса доставки** — это ERP платформа, которая позволяет пользователям заказывать и получать продукты.
Приложение включает в себя такие функции, как просмотр продуктов, выбор вариантов доставки, отслеживание заказов в режиме реального времени и осуществление платежей.

## Общее описание

### Цель

Целью приложения службы доставки в целом является предоставление клиентам удобного и эффективного способа заказа и получения доставки, а также оптимизация процесса для предприятий и курьеров, участвующих в процессе доставки.

Цели проекта — разработать комплексное приложение для службы доставки, отвечающее потребностям всех заинтересованных сторон, участвующих в процессе доставки, включая клиентов, предприятия, курьеров и менеджеров.
Это включает в себя разработку клиентских приложений для каждого типа пользователей, а также серверных служб для поддержки аутентификации, файлов, статистики, прогнозирования, отправки электронной почты и push-уведомлений.

### Область применения

В область применения проекта входит разработка полнофункционального приложения для службы доставки, которое может обрабатывать все аспекты процесса доставки: от заказов клиентов до курьерских доставок. 
Сюда входит разработка клиентских приложений для шести различных типов пользователей, а также серверных служб для поддержки аутентификации, файлов, статистики, прогнозирования, отправки электронной почты и push-уведомлений.

### Кто может использовать это приложение

Приложение предназначено для использования клиентами, предприятиями, курьерами и менеджерами, участвующими в процессе доставки.
Любая компания, предлагающая услуги доставки, потенциально может использовать это приложение, включая рестораны, продуктовые магазины, розничные магазины и другие предприятия, предлагающие услуги доставки.

## Требования к системе и её описание 

### Описание системы

- Виды клиентских приложений по типу конечного пользователя: 
    - [потребителей](docs/frontend/customerclient.ru.md), 
    - [работник](docs/frontend/kitchenclient.ru.md), 
    - [админов](docs/frontend/adminclient.ru.md).
- Описание бэкенд сервисов: 
    - [аутентификации](docs/backend/authbackend.ru.md), 
    - [потребителя](docs/backend/customerbackend.ru.md), 
    - [работника](docs/backend/kitchenbackend.ru.md), 
    - [админа](docs/backend/adminbackend.ru.md), 
    - [системная конфигурация](docs/backend/systembackend.ru.md), 
    - [файловый](docs/backend/fileservice.ru.md), 
    - [статистики](docs/backend/statisticalbackend.ru.md), 
    - [мониторинг](docs/backend/notificationsbackend.ru.md), 
    - [уведомления](docs/backend/notificationsbackend.ru.md).
- Описание паттернов процессов (подробнее про паттерны процессов можно прочитать по [данной ссылке](docs/processpatterns/README.ru.md)):
    - [информация](docs/processpatterns/information.ru.md),
    - [поддержка](docs/processpatterns/maintenance.ru.md),
    - [передача файла](docs/processpatterns/transmittingfile.ru.md),
    - [запрос](docs/processpatterns/requesting.ru.md).
- Описание flowchart-диаграмм (см. также: [flowchart-шаги](docs/flowchartsteps/README.ru.md)):
    - [доставка](docs/flowchartsteps/delivering/README.ru.md).

### Бизнес требования

- Отображение информации по заказам в виде списков: список всех заказов, информация по конкретному заказу (фактическое время оформления, готовки и доставки; ориентировочное время готовки и доставки, общая сумма заказа, стоимость позиций заказа, место доставки; статус).
- Отслеживание местоположения курьера.
- Виды оплаты: 
    - наличная при получении, 
    - через валидатор при получении, 
    - через приложение банка по QR-коду, 
    - в приложении с помощью CVC.
- Файловые операции:
    - Загрузка файлов на сервер (изображения, видео, Word, Excel, PDF).
    - Загрузка файлов с сервера (изображения, Word, Excel, PDF).
- Уведомления:
    - Отправка уведомлений об акциях на почту и/или на телеграм.
- Статистика:
    - Статистика по многим заказам в виде дашбордов (по времени: день, неделя, месяц, год, всё время; по типу графиков: Line chart, Bar chart, Histogram, Scatter plot и т.д.; метрики: общая сумма заказа, стоимость позиции, количество заказов, количество позиций, время оформления заказов, место доставки).
    - Метрики для внутреннего пользования: фактическое время оформления заказов, готовки и доставки; общая сумма заказа, стоимость позиций заказа, количество заказов, количество позиций, время оформления заказов, место доставки, место регистрации пользователя.
    - Предиктивные модели по всем метрикам: для группы пользователей (фильтр: город, страна, возраст, пол, совпадения в ФИО пользователей, место доставки, место регистрации; отображение: список пользователей, краткая информация о пользователе).

### Технические требования

- Распределенная система храненения записей в БД.
- Несколько типов хранилищ: SQL, сессии, file storage.
- Load balancer.
- Виды клиентских приложений по типу развертывания: 
    - вэб (ASP.NET Core MVC, Blazor, React); 
    - десктоп (WPF);
    - мобильное (Xamarin, Android);
    - бот в телеграм.
- Виды бэкенд приложений по типу развертывания: 
    - WebAPI;
    - gRPC.
- Использование RabbitMQ, ElasticSearch, Firebase, [MailKit](https://github.com/jstedfast/MailKit), payment gateway.
- Асинхронность и параллельность (например, при формировании изображений).
- Внешние сервисы: 
    - [workflow-auth](https://github.com/alexeysp11/workflow-auth), 
    - [workflow-lib](https://github.com/alexeysp11/workflow-lib)

### Общая модель системы 

Данная диаграмма отображает список клиентских приложений, бэкэнд-сервисов и БД, а также общий принцип взаимодействия между ними.

На диаграмме отмечено, что админский бэкэнд-сервис является инфраструктурным и имеет доступ ко всем бэкэнд-сервисам и базам данных в рамках прлатформы, поэтому весь функционал, который необходим для всех ИТ-специалистов, в основном проходит через админский бэкэнд-сервис.

Также указан принцип наименования модулей. 

![system_overall](docs/img/system_overall.png)

## Конфигурация проекта 

Для скачивания данного проекта и всех его зависимостей необходимо последовательно выполнить в командной строке следующие команды:
```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
git clone https://github.com/alexeysp11/workflow-auth.git
git clone https://github.com/alexeysp11/delivery-service-csharp.git
```

## Docs

- [Versions of the project](docs/versions.ru.md)
- [TODO](docs/TODO.md)
- [Contributing to projects](https://docs.github.com/en/get-started/quickstart/contributing-to-projects)
- [GitHub flow](https://docs.github.com/en/get-started/quickstart/github-flow)
