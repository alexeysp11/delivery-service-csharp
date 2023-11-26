# deploynetwork

[English](deploynetwork.md) | [Русский](deploynetwork.ru.md)

Name: **Deploying the network**.

The process responsible for deploying the corporate network in the delivery service app involves physically setting up the network infrastructure, installing and configuring networking devices such as routers, switches, and access points, and implementing security measures such as firewalls and intrusion detection systems. This process also involves ensuring that the network is properly connected to the internet and other external networks.

Gateways in a corporate network can be used as entry and exit points for data traffic between the internal network and external networks such as the internet. They can also provide additional security measures such as firewall protection, VPN connectivity, and content filtering.

The process for deploying access points and wireless controllers in the delivery service app involves physically installing and configuring the necessary hardware at the designated delivery locations. This includes mounting access points, connecting them to the network, and setting up wireless controllers to manage and optimize the WIFI network.

To find more information about deploying access points and wireless controllers, you can start by researching best practices for WIFI deployment in similar delivery service apps. Wireless controllers can be implemented as dedicated hardware appliances or as software-based solutions that run on servers or virtual machines.

Process pattern: [maintenance](../../processpatterns/maintenance.md)

Responsible modules: [client application](../../frontend/adminclient.md), [backend service](../../backend/adminbackend.md)

Platform version: v0.3

## Process description

![maintenance_overall](../../img/processpatterns/maintenance_overall.png)

### Step-by-step execution plan of the process

- Admin procures necessary networking hardware and software components based on the design proposal
- Admin installs and configures network devices such as routers, switches, firewalls, and access points
- Admin tests network connectivity, security measures, and performance parameters before full deployment
