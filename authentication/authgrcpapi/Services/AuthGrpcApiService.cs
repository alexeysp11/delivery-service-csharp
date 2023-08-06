using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using DeliveryService.Authentication.AuthGrpcApi;
using DeliveryService.Models.Protos;

namespace DeliveryService.Authentication.AuthGrpcApi.Services;

public class AuthGrpcApiService : DeliveryService.Models.Protos.AuthGrpcApi.AuthGrpcApiBase
{
    private readonly ILogger<AuthGrpcApiService> _logger;
    public AuthGrpcApiService(ILogger<AuthGrpcApiService> logger)
    {
        _logger = logger;
    }

    public override Task<SessionTokenInfo> CreateToken(Empty request, ServerCallContext context)
    {
        var dt = System.DateTime.Now;
        return Task.FromResult(new SessionTokenInfo
        {
            SessionTokenGuid = System.Guid.NewGuid().ToString(),
            TokenActivityBegin = Timestamp.FromDateTime(dt),
            TokenActivityEnd = Timestamp.FromDateTime(dt.AddHours(5))
        });
    }

    public override Task<SessionTokenInfo> CheckTokenPresense(CheckTokenRequest request, ServerCallContext context)
    {
        var dt = System.DateTime.Now;
        return Task.FromResult(new SessionTokenInfo
        {
            SessionTokenGuid = request.SessionTokenGuid,
            TokenActivityBegin = Timestamp.FromDateTime(dt),
            TokenActivityEnd = Timestamp.FromDateTime(dt.AddHours(5))
        });
    }

    public override Task<TokenRelevanceResponse> CheckTokenRelevance(CheckTokenRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TokenRelevanceResponse
        {
            IsRelevant = true
        });
    }
}
