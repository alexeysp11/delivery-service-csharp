# callrouting

[English](callrouting.md) | [Русский](callrouting.ru.md)

Name: **Сall routing**.

The call routing and forwarding process is responsible for managing incoming calls and directing them to the appropriate recipients based on predefined rules or user preferences. 
This may involve features such as call forwarding, call queuing, interactive voice response (IVR) systems, and integration with other communication channels.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.6

## Process description

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution

The step-by-step execution plan for call routing and forwarding in the admin backend service related to IP telephony involves defining call routing rules, configuring call forwarding options, setting up telephony gateways or PBX systems, testing call routing functionality, and ensuring reliable communication for voice calls within the delivery service app.

- Admin defines call routing rules based on predefined criteria such as caller ID, time of day, or user preferences
- Admin configures call forwarding, call queuing, or interactive voice response (IVR) systems to manage incoming calls
- Admin monitors and adjusts call routing settings as needed based on call traffic and user feedback
