using Grpc.Core;
using DeliveryService.Backend.Courier.Grpc;

namespace DeliveryService.Backend.Courier.Grpc.Services;

public class CourierBackendService : CourierBackend.CourierBackendBase
{
    private readonly ILogger<CourierBackendService> _logger;
    public CourierBackendService(ILogger<CourierBackendService> logger)
    {
        _logger = logger;
    }

    public override Task<GrpcApiReply> Store2WhStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Store2WhExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> DeliverOrderStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> DeliverOrderExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }
}
