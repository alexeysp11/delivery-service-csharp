using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using DeliveryService.Backend.Notifications.BL;

namespace DeliveryService.Backend.Notifications.Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsBackendController : ControllerBase
{
    private readonly ILogger<NotificationsBackendController> _logger;
    private NotificationsBackendControllerBL _backendController;

    public NotificationsBackendController(
        ILogger<NotificationsBackendController> logger,
        NotificationsBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    [HttpPost("SendNotifications")]
    public string SendNotifications(IEnumerable<Notification> notifications)
    {
        return _backendController.SendNotifications(notifications);
    }
}
