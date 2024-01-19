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

    [HttpPost(Name = "MakeOrderRequest")]
    public ApiOperation MakeOrderRequest(InitialOrder model)
    {
        var apiOperation = new ApiOperation();
        if (apiOperation == null)
        {
            apiOperation = new ApiOperation();
            apiOperation.ResponseObject = "API operation could not be null";
            return apiOperation;
        }

        // InitialOrder model = apiOperation.RequestObject as InitialOrder;
        if (model == null)
        {
            apiOperation.ResponseObject = "Request object could not be null";
            return apiOperation;
        }
        
        apiOperation.ResponseObject = _backendControllerBL.MakeOrderRequest(model);

        return apiOperation;
    }
}
