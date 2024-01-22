using Microsoft.AspNetCore.Mvc;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Backend.Warehouse.BL.Controllers;

namespace DeliveryService.Backend.Warehouse.BL.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class WarehouseBackendController : ControllerBase
{
    private readonly ILogger<WarehouseBackendController> _logger;
    private WarehouseBackendControllerBL _backendController;

    public WarehouseBackendController(
        ILogger<WarehouseBackendController> logger,
        WarehouseBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    [HttpPost(Name = "PreprocessOrderRedirect")]
    public string PreprocessOrderRedirect(DeliveryOrder model)
    {
        return _backendController.PreprocessOrderRedirect(model);
    }

    [HttpPost(Name = "RequestStore2WhStart")]
    public string RequestStore2WhStart(DeliveryOrder model)
    {
        return _backendController.RequestStore2WhStart(model);
    }

    [HttpPost(Name = "RequestStore2WhRespond")]
    public string RequestStore2WhRespond(DeliveryOrder model)
    {
        return _backendController.RequestStore2WhRespond(model);
    }

    [HttpPost(Name = "Store2WhSave")]
    public string Store2WhSave(DeliveryOrder model)
    {
        return _backendController.Store2WhSave(model);
    }

    [HttpPost(Name = "ConfirmStore2WhAccept")]
    public string ConfirmStore2WhAccept(DeliveryOrder model)
    {
        return _backendController.ConfirmStore2WhAccept(model);
    }

    [HttpPost(Name = "Wh2KitchenStart")]
    public string Wh2KitchenStart(DeliveryOrder model)
    {
        return _backendController.Wh2KitchenStart(model);
    }

    [HttpPost(Name = "Wh2KitchenExecute")]
    public string Wh2KitchenExecute(DeliveryOrder model)
    {
        return _backendController.Wh2KitchenExecute(model);
    }

    [HttpPost(Name = "Kitchen2WhStart")]
    public string Kitchen2WhStart(DeliveryOrder model)
    {
        return _backendController.Kitchen2WhStart(model);
    }

    [HttpPost(Name = "Kitchen2WhExecute")]
    public string Kitchen2WhExecute(DeliveryOrder model)
    {
        return _backendController.Kitchen2WhExecute(model);
    }
}
