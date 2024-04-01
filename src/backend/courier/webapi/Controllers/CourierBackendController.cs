using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Backend.Courier.BL.Controllers;

namespace DeliveryService.Backend.Courier.Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourierBackendController : ControllerBase
{
    private readonly ILogger<CourierBackendController> _logger;
    private CourierBackendControllerBL _backendController;

    public CourierBackendController(
        ILogger<CourierBackendController> logger,
        CourierBackendControllerBL backendController)
    {
        _logger = logger;
        _backendController = backendController;
    }

    [HttpPost("Store2WhStart")]
    public string Store2WhStart(DeliveryOrder model)
    {
        return _backendController.Store2WhStart(model);
    }

    [HttpPost("Store2WhExecute")]
    public string Store2WhExecute(DeliveryOrder model)
    {
        return _backendController.Store2WhExecute(model);
    }

    [HttpPost("DeliverOrderStart")]
    public string DeliverOrderStart(DeliveryOrder model)
    {
        return _backendController.DeliverOrderStart(model);
    }

    [HttpPost("DeliverOrderExecute")]
    public string DeliverOrderExecute(DeliveryOrder model)
    {
        return _backendController.DeliverOrderExecute(model);
    }
}
