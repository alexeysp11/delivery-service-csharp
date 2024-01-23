using Microsoft.AspNetCore.Mvc;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Backend.Kitchen.BL.Controllers;

namespace DeliveryService.Backend.Kitchen.Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class KitchenBackendController : ControllerBase
{
    private readonly ILogger<KitchenBackendController> _logger;
    private KitchenBackendControllerBL _backendController;

    public KitchenBackendController(
        ILogger<KitchenBackendController> logger,
        KitchenBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    [HttpPost("PrepareMealStart")]
    public string PrepareMealStart(DeliveryOrder model)
    {
        return _backendController.PrepareMealStart(model);
    }

    [HttpPost("PrepareMealExecute")]
    public string PrepareMealExecute(DeliveryOrder model)
    {
        return _backendController.PrepareMealExecute(model);
    }
}
