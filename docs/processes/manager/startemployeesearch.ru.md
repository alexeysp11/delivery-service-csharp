# startemployeesearch 

[English](startemployeesearch.md) | [Русский](startemployeesearch.ru.md)

Наименование: **Начать поиск сотрудника**.

Сценарий, отвечающий за запуск поиска сотрудников менеджером, позволяет осуществлять поиск сотрудников (кандидатов) для работы в компании по различным критериям.
Это позволяет менеджерам формировать базу кандидатов, а также быстро находить и общаться с нужными кандидатами для приёма на работу.

Данный сценарий включает в себя следующие процессы:
- процесс согласования поиска сотрудника на этапе подготовки (согласующие: нанимающий менеджер, руководители 1-го и 2-го уровня, руководитель департамента, финансовый директор, генеральный директор);
- процессы скрининга, отбора, найма и онбоардинга объединяются в один поток для каждого кандидата (для каждого кандидата этот поток запускается свой, теоритечески может быть запущено неограниченное количество потоков): такое решение позволяет одновременно проводить серии интервью для нескольких кандидатов на одну позицию, а также нанимать нескольких кандидиатов на одну позицию и отслеживать их прогресс во время испытательного срока.

Паттерн процесса: [requesting](../../processpatterns/requesting.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/managerclient.md), [бэкэнд-сервис](../../backend/managerbackend.md).

Версия платформы: v0.2

## Зависимости

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.ru.md) | [approval](../manager/approval.ru.md) |
| [hrbackend](../../backend/hrbackend.ru.md) | [candidateselection](../hr/candidateselection.ru.md) |

## Описание процесса

Внешние сервисы, которые можно использовать для получения информации о потенциальных кандидатах при поиске нового сотрудника менеджером в компании, занимающейся доставкой, включают сайты объявлений о вакансиях (например, Indeed, Glassdoor), рекрутинговые агентства и профессиональные сетевые сайты (например, LinkedIn).

Полный цикл подбора персонала:
- Подготовка (прием вакансий с менеджером по найму, составление описания вакансии, составление объявления о вакансии),
- Поиск кандидатов (подбор кандидатов, проверка существующего кадрового резерва, информирование менеджера по найму),
- Скрининг (экран резюме, проверка телефона, реалистичный предварительный просмотр вакансии),
- Отбор (тесный контакт с менеджером по найму, использование руководства по собеседованию для структурирования процесса, автоматизация планирования собеседований),
- Найм (проверка рекомендаций, проверка анкетных данных, поддержка менеджера в принятии решения о найме на основе данных).

![requesting_overall](../../img/processpatterns/requesting_overall.png)

### План пошагового выполнения процесса

- Менеджер открывает приложение для менеджеров.
- Руководитель выбирает вариант запуска поиска сотрудника.
- Начинается процесс согласования (на данном этапе в любой момент процесс может быть отклонён и возвращён менеджеру на доработку).
- После согласования HR менеджер публикует вакансию.
- По мере получения новых резюме, HR менеджер регистрирует нового кандидата (после этого на бэкэнд-сервисе создается "контекст" или "поток" для работы с конкретным кандидатом).
- Если на должность несколько кандидатов, система уведомляет HR о необходимости назначить собеседования с каждым кандидатом.
- После проведения собеседований интервьюеры предоставляют отзывы и оценки каждому кандидату.
- Менеджер изучает отзывы и рейтинги и выбирает наиболее подходящего кандидата на должность.
- Система уведомляет выбранного кандидата и HR о продолжении процесса найма.

![manager.startemployeesearch](../../img/activitydiagrams/manager.startemployeesearch.png)
