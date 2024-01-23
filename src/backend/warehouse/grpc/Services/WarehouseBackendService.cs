using Grpc.Core;
using DeliveryService.Backend.Warehouse.Grpc;

namespace DeliveryService.Backend.Warehouse.Grpc.Services;

public class WarehouseBackendService : WarehouseBackend.WarehouseBackendBase
{
    private readonly ILogger<WarehouseBackendService> _logger;
    public WarehouseBackendService(ILogger<WarehouseBackendService> logger)
    {
        _logger = logger;
    }

    public override Task<GrpcApiReply> PreprocessOrderRedirect(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> RequestStore2WhStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> RequestStore2WhRespond(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Store2WhSave(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> ConfirmStore2WhAccept(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Wh2KitchenStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Wh2KitchenExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Kitchen2WhStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<GrpcApiReply> Kitchen2WhExecute(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }
}
