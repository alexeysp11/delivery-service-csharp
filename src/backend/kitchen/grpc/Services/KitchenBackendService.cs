using Grpc.Core;
using DeliveryService.Backend.Kitchen.Grpc;

namespace DeliveryService.Backend.Kitchen.Grpc.Services;

public class KitchenBackendService : KitchenBackend.KitchenBackendBase
{
    private readonly ILogger<KitchenBackendService> _logger;
    public KitchenBackendService(ILogger<KitchenBackendService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> PrepareMealStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> PrepareMealExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
