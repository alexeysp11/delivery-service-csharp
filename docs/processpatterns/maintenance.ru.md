# maintenance

[English](maintenance.md) | [Русский](maintenance.ru.md)

`maintenance` - это паттерн реализации бизнес-процессов, которые обычно связаны с поддержкой функциональности клиентского приложения, бэкенд-сервиса или бизнес-процесса. 
Такие процессы начинают своё выполнение на бэкенд-сервисе после вызова со стороны другого сервиса либо по триггеру, а также могут отправлять пользователю уведомление о необходимости выполнить некоторое действие и обрабатывать результат выполнения данного действия. 

![maintenance_overall](../img/maintenance_overall.png)