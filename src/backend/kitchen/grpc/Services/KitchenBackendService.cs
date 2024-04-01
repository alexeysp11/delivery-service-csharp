using Grpc.Core;
using WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Backend.Kitchen.BL.Controllers;
using DeliveryService.Backend.Kitchen.Grpc;

namespace DeliveryService.Backend.Kitchen.Grpc.Services;

public class KitchenBackendService : KitchenBackend.KitchenBackendBase
{
    private readonly ILogger<KitchenBackendService> _logger;
    private KitchenBackendControllerBL _backendController;

    public KitchenBackendService(
        ILogger<KitchenBackendService> logger,
        KitchenBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    public override Task<GrpcApiReply> PrepareMealStart(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.PrepareMealStart(model)
        });
    }

    public override Task<GrpcApiReply> PrepareMealExecute(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.PrepareMealExecute(model)
        });
    }
}
