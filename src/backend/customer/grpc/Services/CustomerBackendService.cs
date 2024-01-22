using Grpc.Core;
using DeliveryService.Backend.Customer.Grpc;

namespace DeliveryService.Backend.Customer.Grpc.Services;

public class CustomerBackendService : Greeter.GreeterBase
{
    private readonly ILogger<CustomerBackendService> _logger;
    public CustomerBackendService(ILogger<CustomerBackendService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> MakeOrderRequest(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> MakePaymentStart(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> MakePaymentRespond(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<HelloReply> PreprocessOrderRedirect(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
