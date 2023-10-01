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

    [HttpPost]
    public UserCreationResult AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }

    [HttpPost]
    public VSUResponse VerifySignUp(VSURequest request)
    {
        return new AuthResolver().VerifySignUp(request);
    }
}
