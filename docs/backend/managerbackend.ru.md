# managerbackend

[English](managerbackend.md) | [Русский](managerbackend.ru.md)

`managerbackend` — это бэкенд сервис, предоставляющий инструменты аналитики и отчетности для владельцев бизнеса.

Серверная служба для менеджеров в приложении службы доставки предоставляет комплексное представление обо всех заказах, уровнях запасов и статусе доставки в нескольких местах.

Оно позволяет менеджерам отслеживать показатели производительности, управлять уровнями запасов, отслеживать сроки доставки и получать уведомления, когда продукты заканчиваются или когда возникают задержки в доставке, а также оптимизировать маршруты/способы доставки.
Служба также предоставляет возможности аналитики и отчетности, которые помогают менеджерам принимать решения на основе данных и улучшать общие бизнес-операции.

Кроме того, он предоставляет возможности аналитики и отчетности, которые помогают менеджерам оптимизировать управление запасами и повысить эффективность доставки.

[Клиентское приложение](../frontend/managerclient.ru.md)

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Начать поиск сотрудника](../processes/manager/startemployeesearch.ru.md)
- [Прекращение трудоустройства](../processes/manager/terminationofemployment.ru.md)
- [Управлять взаимоотношениями с поставщиками](../processes/manager/supplierrelationships.ru.md)
- [Отслеживать производительность](../processes/manager/trackperformance.ru.md)
- [Получать уведмления о проблемах](../processes/notificationsbackend/getnotified.ru.md)
- [Сформировать бизнес-отчет](../processes/manager/businessreport.ru.md)
- [Уведомить сотрудников](../processes/notificationsbackend/notifymanual.ru.md)
- [Изменить плановые запасы](../processes/manager/inventorylevels.ru.md)
- [Оптимизировать доставку](../processes/manager/optimizedelivery.ru.md)
- [Согласование](../processes/manager/approval.ru.md)
