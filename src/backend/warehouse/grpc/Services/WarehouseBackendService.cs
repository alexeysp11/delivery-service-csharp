using Grpc.Core;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Backend.Warehouse.BL.Controllers;
using DeliveryService.Backend.Warehouse.Grpc;

namespace DeliveryService.Backend.Warehouse.Grpc.Services;

public class WarehouseBackendService : WarehouseBackend.WarehouseBackendBase
{
    private readonly ILogger<WarehouseBackendService> _logger;
    private WarehouseBackendControllerBL _backendController;

    public WarehouseBackendService(
        ILogger<WarehouseBackendService> logger,
        WarehouseBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    public override Task<GrpcApiReply> PreprocessOrderRedirect(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.PreprocessOrderRedirect(model)
        });
    }

    public override Task<GrpcApiReply> RequestStore2WhStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.RequestStore2WhStart(model)
        });
    }

    public override Task<GrpcApiReply> RequestStore2WhRespond(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.RequestStore2WhRespond(model)
        });
    }

    public override Task<GrpcApiReply> Store2WhSave(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Store2WhSave(model)
        });
    }

    public override Task<GrpcApiReply> ConfirmStore2WhAccept(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.ConfirmStore2WhAccept(model)
        });
    }

    public override Task<GrpcApiReply> Wh2KitchenStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Wh2KitchenStart(model)
        });
    }

    public override Task<GrpcApiReply> Wh2KitchenExecute(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Wh2KitchenExecute(model)
        });
    }

    public override Task<GrpcApiReply> Kitchen2WhStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Kitchen2WhStart(model)
        });
    }

    public override Task<GrpcApiReply> Kitchen2WhExecute(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Kitchen2WhExecute(model)
        });
    }
}
