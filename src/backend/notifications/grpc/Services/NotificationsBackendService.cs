using Grpc.Core;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using DeliveryService.Backend.Notifications.BL;
using DeliveryService.Backend.Notifications.Grpc;

namespace DeliveryService.Backend.Notifications.Grpc.Services;

public class NotificationsBackendService : NotificationsBackend.NotificationsBackendBase
{
    private readonly ILogger<NotificationsBackendService> _logger;
    private NotificationsBackendControllerBL _backendController;

    public NotificationsBackendService(
        ILogger<NotificationsBackendService> logger,
        NotificationsBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    public override Task<GrpcApiReply> SendNotifications(NotificationsRequest request, ServerCallContext context)
    {
        var notifications = new List<Notification>();
        foreach (var grpcNotification in request.Notifications)
        {
            notifications.Add(new Notification
            {
                TitleText = grpcNotification.TitleText,
                BodyText = grpcNotification.BodyText
            });
        }
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.SendNotifications(notifications)
        });
    }
}
