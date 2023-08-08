using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using DeliveryService.Authentication.AuthBL;
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

    /// <summary>
    /// Creates unique token
    /// </summary>
    public override Task<SessionTokenInfo> CreateToken(Empty request, ServerCallContext context)
    {
        var token = new TokenHelper().CreateToken();
        return Task.FromResult(new SessionTokenInfo
        {
            SessionTokenGuid = token.SessionTokenGuid.ToString(),
            TokenActivityBegin = Timestamp.FromDateTimeOffset(token.TokenActivityBegin),
            TokenActivityEnd = Timestamp.FromDateTimeOffset(token.TokenActivityEnd)
        });
    }

    /// <summary>
    /// Check if the specified token exists in the database
    /// </summary>
    public override Task<SessionTokenInfo> GetTokenByGuid(TokenRequest request, ServerCallContext context)
    {
        var token = new TokenHelper().GetTokenByGuid(new System.Guid(request.SessionTokenGuid));
        return Task.FromResult(new SessionTokenInfo
        {
            SessionTokenGuid = request.SessionTokenGuid,
            TokenActivityBegin = Timestamp.FromDateTimeOffset(token.TokenActivityBegin),
            TokenActivityEnd = Timestamp.FromDateTimeOffset(token.TokenActivityEnd)
        });
    }
}
