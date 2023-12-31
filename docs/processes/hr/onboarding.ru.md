# onboarding

[English](onboarding.md) | [Русский](onboarding.ru.md)

Наименование: **Онбординг**.

Процесс адаптации новых сотрудников включает в себя предоставление им необходимого обучения и ресурсов для эффективной интеграции в свои роли в приложении службы доставки.

Паттерн процесса: [maintenance](../../processpatterns/maintenance.ru.md)

Ответственные модули: [клиентское приложение](../../frontend/hrclient.ru.md), [бэкенд-сервис](../../backend/hrbackend.ru.md)

Версия платформы: v0.2

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [hrbackend](../../backend/hrbackend.ru.md) | [candidateselection](../hr/candidateselection.ru.md) |

### Влияет на

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [notificationsbackend](../../backend/notificationsbackend.ru.md) | [sendnotifications](../notificationsbackend/sendnotifications.ru.md) |

## Описание процесса

Этапы адаптации сотрудников:
- Pre-boarding: подготовка к адаптации;
- 1-й день: прием нового сотрудника;
- 1-я неделя: знакомство с компанией, другими сотрудниками и ролью;
- 1-й месяц: обучение и подготовка;
- 2-й месяц: check-in и обратная связь;
- 3-й месяц: check-in и обратная связь;
- 6-й месяц: check-in и обратная связь.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### План пошагового выполнения процесса

- На бэкэнд-сервис приходит запрос на начало онбординга сотрудника (в качестве параметров: персональная информация, результаты интервью, заметки и рекомендации).
- Приветствие нового сотрудника в компании (выполняется через рассылку).
- Обеспечение доступа к необходимым учебным материалам и ресурсам.
- Назначение наставника или приятеля, который будет сопровождать нового сотрудника в процессе адаптации.
- Оценить готовность кандидата интегрироваться в свои роли в компании.
- В начале 2-й недели отправить сотруднику план адаптации, сотрудник должен подписать его (в плане адаптации указываются основные check point'ы и критерии оценки).
- Отслеживать прогресс и завершение учебных модулей.
- В установленные сроки система отправляет уведомление сотруднику, менеджеру и HR-специалисту о необходимости проведения встречи для сбора обратной связи.
- В любой момент во время онбординга менеджер может сигнализировать о проблемах при адаптации специалиста.

![hr.onboarding](../../img/activitydiagrams/hr.onboarding.png)
