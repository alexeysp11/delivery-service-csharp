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

    public override Task<GrpcApiReply> PrepareMealStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> PrepareMealExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }
}
