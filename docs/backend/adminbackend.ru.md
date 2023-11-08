# adminbackend

[English](adminbackend.md) | [Русский](adminbackend.ru.md)

`adminbackend` — это бэкенд сервис, который позволяет администраторам управлять пользователями, продуктами и заказами.

Бэкенд-сервис, отвечающий за управление запросами администраторов в компании, занимающейся доставкой, представляет собой веб-приложение, которое обрабатывает аутентификацию пользователей, управление базой данных, запросы API и другие задачи на стороне сервера.
Он взаимодействует со всеми клиентскими приложениями и обеспечивает централизованное управление всей службой доставки.

[Клиентское приложение](../frontend/adminclient.ru.md)

## Общая модель системы 

![system_overall](../img/system_overall.png)

## Процессы 

- [Вход](../processes/auth/signin.ru.md)
- [Пинговать сервисы](../processes/admin/pingservices.ru.md)
- [Управление разрешениями](../processes/admin/managepermissions.ru.md)
- [Управление уровнями доступа](../processes/admin/manageaccesslevels.ru.md)
- [Развернуть сервис из GitHub](../processes/admin/deployservice.ru.md)
- [Репликация БД](../processes/admin/dbreplication.ru.md)
- [Очистка кэша](../processes/admin/clearcache.ru.md)
- [Развертывание телефонов](../processes/admin/deploytelephones.ru.md)
- [Маршрутизация вызовов](../processes/admin/callrouting.ru.md)
- [Система IVR](../processes/admin/ivrsystem.ru.md)
- [Наблюдение за телефонными сеансами](../processes/admin/watchtelephonesessions.ru.md)
- [Планирование/проектирование сети](../processes/admin/designnetwork.ru.md)
- [Развертывание сети](../processes/admin/deploynetwork.ru.md)
- [Балансировка нагрузки](../processes/admin/loadbalancing.ru.md)
- [Настроить прокси](../processes/admin/configureproxy.ru.md)
- [VPN](../processes/admin/vpn.ru.md)
- [Реализация качества обслуживания (QoS) для определения приоритета сетевого трафика](../processes/admin/qos.ru.md)
- [Планирование аварийного восстановления](../processes/admin/disasterrecoveryplanning.ru.md)
- [Поддержка WIFI](../processes/techsupport/supportwifi.ru.md)
- [Наблюдение за проблемами с безопасностью](../processes/admin/watchnetworkproblems.ru.md)
- [Запрос на серьезные изменения](../processes/admin/majorchangerequest.ru.md)
- [Запрос на незначительные изменения](../processes/admin/minorchangerequest.ru.md)
