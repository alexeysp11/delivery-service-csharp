# generateqr

[English](generateqr.md) | [Русский](generateqr.ru.md)

Наименование: **Сгенерировать QR код**.

Сценарий, отвечающий за генерацию QR-кодов в компании службы доставки, предполагает создание уникальных кодов для каждого заказа или посылки для обеспечения отслеживания и проверки.

Паттерн процесса: [transmittingfile](../../processpatterns/transmittingfile.ru.md)

Ответственные модули: [бэкенд-сервис](../../backend/fileservice.ru.md)

Версия платформы: v0.1

## Зависимости

### Зависит от

| Бэкэнд-сервис | Процесс |
| --- | ---- |
| [customerbackend](../../backend/customerbackend.ru.md) | [makepayment](../../flowchartsteps/delivering/makepayment.ru.md) |

## Описание процесса

![transmittingfile_overall](../../img/processpatterns/transmittingfile_overall.png)

### План пошагового выполнения процесса

- Запрос приходит на бэкэнд-сервис [fileservice](../../backend/fileservice.ru.md).
- Запрос обрабатывается на наличие ошибок.
- Формируется файл.
- Файл отправляетя в качестве ответа на запрос.

![fileservice.getpdf](../../img/activitydiagrams/fileservice.getpdf.png)
