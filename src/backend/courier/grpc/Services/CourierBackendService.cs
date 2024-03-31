using Grpc.Core;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Backend.Courier.BL.Controllers;
using DeliveryService.Backend.Courier.Grpc;

namespace DeliveryService.Backend.Courier.Grpc.Services;

public class CourierBackendService : CourierBackend.CourierBackendBase
{
    private readonly ILogger<CourierBackendService> _logger;
    private CourierBackendControllerBL _backendController;

    public CourierBackendService(
        ILogger<CourierBackendService> logger,
        CourierBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    public override Task<GrpcApiReply> Store2WhStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Store2WhStart(model)
        });
    }

    public override Task<GrpcApiReply> Store2WhExecute(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.Store2WhExecute(model)
        });
    }

    public override Task<GrpcApiReply> DeliverOrderStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.DeliverOrderStart(model)
        });
    }

    public override Task<GrpcApiReply> DeliverOrderExecute(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.DeliverOrderExecute(model)
        });
    }
}
