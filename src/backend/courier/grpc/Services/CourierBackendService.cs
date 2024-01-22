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

    public override Task<HelloReply> Store2WhStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> Store2WhExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> DeliverOrderStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> DeliverOrderExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
