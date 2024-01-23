using Microsoft.AspNetCore.Mvc;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Backend.Customer.BL.Controllers;

namespace DeliveryService.Backend.Customer.Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerBackendController : ControllerBase
{
    private readonly ILogger<CustomerBackendController> _logger;
    private CustomerBackendControllerBL _backendControllerBL;

    public CustomerBackendController(
        ILogger<CustomerBackendController> logger, 
        CustomerBackendControllerBL backendControllerBL)
    {
        _logger = logger;
        _backendControllerBL = backendControllerBL;
    }

    [HttpPost("MakeOrderRequest")]
    public string MakeOrderRequest(InitialOrder model)
    {
        return _backendControllerBL.MakeOrderRequest(model);
    }

    [HttpPost("MakePaymentStart")]
    public string MakePaymentStart(InitialOrder model)
    {
        return _backendControllerBL.MakePaymentStart(model);
    }

    [HttpPost("MakePaymentRespond")]
    public string MakePaymentRespond(DeliveryOrder model)
    {
        return _backendControllerBL.MakePaymentRespond(model);
    }

    [HttpPost("PreprocessOrderRedirect")]
    public string PreprocessOrderRedirect(DeliveryOrder model)
    {
        return _backendControllerBL.PreprocessOrderRedirect(model);
    }
}
