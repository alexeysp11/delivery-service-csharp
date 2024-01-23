using Grpc.Core;
using DeliveryService.Backend.Notifications.Grpc;

namespace DeliveryService.Backend.Notifications.Grpc.Services;

public class NotificationsBackendService : NotificationsBackend.NotificationsBackendBase
{
    private readonly ILogger<NotificationsBackendService> _logger;
    public NotificationsBackendService(ILogger<NotificationsBackendService> logger)
    {
        _logger = logger;
    }

    public override Task<GrpcApiReply> SendNotifications(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }
}
