using Grpc.Core;
using grpc;

namespace grpc.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<GrpcApiReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GrpcApiReply
        {
            Message = "Hello " + request.Name
        });
    }
}
