# watchnetworkproblems

[English](watchnetworkproblems.md) | [Русский](watchnetworkproblems.ru.md)

Name: **Watch for security problems**.

Scenario that is responsible for watching for security problems on the computers and on the corporate network.

While watching for security problems on the computer and on the network can be considered as separate functionalities, they can be part of a single overarching business process for security management. 
This process would involve continuous monitoring of computer and network security, identifying vulnerabilities and threats, implementing security measures such as firewalls and antivirus software, and responding to security incidents.

Watching for problems in the network of clients may involve both actively monitoring the network for anomalies and security incidents as well as waiting for security incident reports from clients. This could include using network monitoring tools to detect unusual traffic patterns, unauthorized access attempts, or other signs of potential security threats.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.3

## Process description

The process responsible for network performance monitoring and optimization in the delivery service app involves continuously monitoring network traffic, bandwidth usage, latency, and other performance metrics to identify bottlenecks or issues that could impact user experience. This process also involves optimizing network configurations and resources to improve overall performance.

Integrating with antivirus software from Microsoft on the client side can be achieved by using the Windows Security Center API, which allows third-party software to integrate with the built-in Windows Defender Antivirus. This integration would allow your delivery service app to communicate with the antivirus software and receive information about security threats and status.

Integrating with firewalls on the client side involves ensuring that your app can work seamlessly with the firewall rules and configurations set by the user or the network administrator. This may involve using specific network protocols, ports, or exceptions to ensure that your app can communicate effectively while maintaining security.

Implementing security measures such as firewalls and antivirus software involves ensuring that these tools are properly installed, configured, and regularly updated on all client devices. This includes educating users about the importance of these security measures and providing clear instructions for installation and maintenance.

The main vulnerabilities and threats in a corporate network can include malware, phishing attacks, data breaches, insider threats, insecure network configurations, and unpatched software. Preventing these threats involves implementing strong access controls, regular security training for employees, keeping software and systems up to date, using encryption, and implementing network monitoring and intrusion detection systems.

Understanding how firewalls work can start with learning about the different types of firewalls (e.g., packet filtering, stateful inspection, application-layer), how they filter network traffic based on rules, and how they can be configured to allow or block specific types of traffic. 

Actively monitoring the network for problems in the network of clients involves using network monitoring tools to continuously track network performance, traffic patterns, security events, and device statuses. This may also involve setting up alerts and notifications to quickly respond to any detected issues.

To understand the implementation of proxies in a corporate network, you can start by learning about different types of proxies (e.g., forward proxy, reverse proxy), their use cases, configuration options, and potential security considerations. You can also explore how proxies can be used for content filtering, caching, load balancing, and enhancing network security. There are many online resources, tutorials, and courses available that can help you gain a deeper understanding of proxy implementation in corporate networks.

The process for implementing security measures in the delivery service app involves configuring encryption protocols, setting up authentication methods for WIFI access, and ensuring that data transmitted over the network is protected. If you already have an external service handling authentication and data caching, you may not need to implement additional authentication measures in this process, but you should still ensure that the WIFI network itself is secure.

The process for monitoring WIFI performance and usage in the delivery service app involves collecting and analyzing data from access points and controllers to assess network performance, identify potential issues, and track usage patterns. This helps to ensure that the WIFI network is operating efficiently and effectively.

Measures for monitoring WIFI performance and usage may include tracking signal strength, throughput, and latency, identifying areas of congestion or interference, and monitoring user activity and bandwidth consumption.

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution plan of the process

- Implement security monitoring tools to track and analyze network activity for potential security threats.
- Regularly review logs and reports from security monitoring tools to identify any suspicious or unauthorized activity.
- Investigate and respond to any security incidents or breaches that are detected.
- Continuously update and improve security measures to protect against evolving threats.

## Data structures

### Objects 

- SecurityIncidentReport
    - A security incident report should include details such as the nature of the incident, the impact on the system or network, the date and time of the incident, any actions taken in response, and recommendations for preventing similar incidents in the future. The object storing this information could have properties such as incident type, affected systems, timestamp, severity level, and methods for updating and retrieving incident information.
