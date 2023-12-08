using Microsoft.AspNetCore.Mvc;
using DeliveryService.Authentication.AuthWebApi.AuthBL;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace DeliveryService.Authentication.AuthWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("AddUser")]
    public UserCreationResult AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }

    [HttpPost("VerifySignUp")]
    public VSUResponse VerifySignUp(VSURequest request)
    {
        return new AuthResolver().VerifySignUp(request);
    }

    [HttpPost("VerifyUserCredentials")]
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return new AuthResolver().VerifyUserCredentials(request);
    }

    [HttpPost("GetTokenByUserUid")]
    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        return new AuthResolver().GetTokenByUserUid(request);
    }
}
