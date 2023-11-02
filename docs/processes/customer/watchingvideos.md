# watchingvideos

[English](watchingvideos.md) | [Русский](watchingvideos.ru.md)

Backend of the customer application: watching videos.

The watch videos scenario in the delivery service app involves allowing users to access and watch videos either downloaded from the app's backend service or retrieved from YouTube.

Macro process: [information](../../macroprocesses/information.md)

Responsible modules: [client application](../../frontend/customerclient.md), [backend service](../../backend/customerbackend.md)

## Process description

- Interacts with the [file service](../../backend/fileservice.md).

![information_overall](../../img/information_overall.png)

### Step-by-step execution

- User selects a video to watch.
- The system checks if the video is available in the backend service.
- If the video is available, the system streams it to the user's device.
- If the video is not available in the backend service, the system retrieves it from YouTube.
- The system streams the video from YouTube to the user's device.

## Data

### Objects

- Video
    - Video object could have properties like title, description, length, genre, etc. 
- Customer
- WatchedVideo
    - WatchedVideo object could have a reference to the Video object and properties like date watched, watch duration, etc. 

### DTOs

- WatchedVideoDTO
    - WatchedVideoDTO could have properties like videoId, dateWatched, watchDuration, etc.
