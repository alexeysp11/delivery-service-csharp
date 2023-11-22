# getpdf

[English](getpdf.md) | [Русский](getpdf.ru.md)

Name: **Get PDF file**.

The scenario responsible for generating and/or retrieving PDF files in the delivery service company.

Process pattern: [transmittingfile](../../processpatterns/transmittingfile.md)

Responsible modules: [backend service](../../backend/fileservice.md)

Platform version: v0.1

## Dependencies

### Depends on

| Backend service | Process |
| --- | ---- |
| [managerbackend](../../backend/managerbackend.md) | [terminationofemployment](../manager/terminationofemployment.md) |

## Process description

![transmittingfile_overall](../../img/processpatterns/transmittingfile_overall.png)

### Step-by-step execution

- The request goes to the backend service [fileservice](../../backend/fileservice.ru.md).
- The request is being processed for errors.
- The file is being generated.
- The file is sent as a response to the request.

![fileservice.getpdf](../../img/activitydiagrams/fileservice.getpdf.png)
