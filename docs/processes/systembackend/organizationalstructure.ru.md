# organizationalstructure

[English](organizationalstructure.md) | [Русский](organizationalstructure.ru.md)

Наименование: **Организационная структура**.

Данный сценарий также предполагает использование приложения управления для поиска сотрудников по различным критериям, таким как имя, отдел или местоположение.
Это позволяет менеджерам быстро находить и общаться с нужными сотрудниками для конкретных задач или проектов.

Паттерн процесса: [information](../../processpatterns/information.md)

Ответственные модули: [бэкенд-сервис](../../backend/systembackend.ru.md)

Версия платформы: v0.2

## Описание процесса

![information_overall](../../img/processpatterns/information_overall.png)

### План пошагового выполнения процесса

- Приложение отображает панель поиска, где менеджер может ввести имена сотрудников, должности или другие соответствующие ключевые слова.
- Приложение возвращает список сотрудников, соответствующих критериям поиска.
- Менеджер может просматривать профили сотрудников, включая контактную информацию, историю работы и показатели производительности.
- Менеджер может использовать эту информацию для принятия обоснованных решений о расписании, повышении по службе или дисциплинарных мерах.

![systembackend.organizationalstructure](../../img/activitydiagrams/systembackend.organizationalstructure.png)
