# fileservice

[English](fileservice.md) | [Русский](fileservice.ru.md). 

`fileservice` is a backend service that manages file storage and retrieval.

The backend service responsible for getting and receiving files in the delivery service app is a file transfer service. Its possible functionalities include:
- Uploading files to the server
- Downloading files from the server
- Storing files on the server
- Retrieving files from the server
- Checking file integrity
- Handling file permissions and access control

## Overall description of the system 

![system_overall](../img/system_overall.png)

## Service description

- Upload files to the server (images, videos, Word, Excel, PDF)
- Download files from the server (images, Word, Excel, PDF)
- Generation of a QR code for payment

### Technical description of the service

- It is possible to make only one method for the service (input parameters: session token, file type, values for generating a file; output parameters: session token, uid of the generated file, file type, file body as an array of bytes)
- uid of the generated file is needed so that the generated file can be cached and easily found in the database
- Saves generated file
- From the point of view of this service, there is no difference whether files are uploaded to the server or from it
- It is necessary to provide in the system the ability to save files on a separate dedicated server and periodically clean the file system from the created files: since the system processes a large number of requests, a lot of files are also created, respectively, there is a risk of running out of hard disk space.

<!--
### Claculations 

- Resolution: 720p
- Measurement (in pixels): 1280x720
- Pixel count: 921,600
- Number of frames per second: 24 fps 
    - The image is updated every 41.5 ms (or 0.041 s)
- Data transimmited per second: 22,118,400 bytes (about 22 MB)
-->

### Possible restrictions

- Files size
- Image resolution
- Files could be transmitted during streaming

<!--
Video resolution: 

![video-resolution](https://zidivo.com/wp-content/uploads/2020/09/video-resolution.png)
-->

## Processes 

- [Generate QR code](../processes/fileservice/generateqr.md)
