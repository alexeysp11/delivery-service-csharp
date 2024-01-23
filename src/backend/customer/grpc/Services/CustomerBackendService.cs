using Grpc.Core;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Backend.Customer.BL.Controllers;
using DeliveryService.Backend.Customer.Grpc;

namespace DeliveryService.Backend.Customer.Grpc.Services;

public class CustomerBackendService : CustomerBackend.CustomerBackendBase
{
    private readonly ILogger<CustomerBackendService> _logger;
    private CustomerBackendControllerBL _backendController;

    public CustomerBackendService(
        ILogger<CustomerBackendService> logger,
        CustomerBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    public override Task<GrpcApiReply> MakeOrderRequest(InitialOrderRequest request, ServerCallContext context)
    {
        string response = string.Empty;
        try
        {
            var model = RequestToInitialOrder(request);
            response = _backendController.MakeOrderRequest(model);
        }
        catch (System.Exception ex)
        {
            response = ex.Message;
        }
        return Task.FromResult(new GrpcApiReply
        {
            Message = response
        });
    }

    public override Task<GrpcApiReply> MakePaymentStart(InitialOrderRequest request, ServerCallContext context)
    {
        string response = string.Empty;
        try
        {
            var model = RequestToInitialOrder(request);
            response = _backendController.MakePaymentStart(model);
        }
        catch (System.Exception ex)
        {
            response = ex.Message;
        }
        return Task.FromResult(new GrpcApiReply
        {
            Message = response
        });
    }

    public override Task<GrpcApiReply> MakePaymentRespond(DeliveryOrderRequest request, ServerCallContext context)
    {
        var model = new DeliveryOrder
        {
            Id = request.Id
        };
        return Task.FromResult(new GrpcApiReply
        {
            Message = _backendController.MakePaymentRespond(model)
        });
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

    private InitialOrder RequestToInitialOrder(InitialOrderRequest request)
    {
        return new InitialOrder
        {
            UserUid = request.UserUid,
            Login = request.Login,
            PhoneNumber = request.PhoneNumber,
            City = request.City,
            Address = request.Address,
            ProductIds = request.ProductIds,
            PaymentType = request.PaymentType,
            PaymentMethod = request.PaymentMethod,
            PaymentAmount = decimal.Parse(request.PaymentAmount)
        };
    }
}
