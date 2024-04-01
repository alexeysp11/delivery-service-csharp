using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using DeliveryService.Frontend.Kitchen.Mvc.Models;
using DeliveryService.Frontend.Kitchen.BL.Controllers;

namespace DeliveryService.Frontend.Kitchen.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private KitchenClientController _clientController;

    public HomeController(
        ILogger<HomeController> logger,
        KitchenClientController clientController)
    {
        _logger = logger;
        _clientController = clientController;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult PrepareMealExecute()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult PrepareMealExecute(DeliveryOrder model)
    {
        string preparingOrderMsg = string.Empty;
        try
        {
            // if (model == null || string.IsNullOrWhiteSpace(model.City) || string.IsNullOrWhiteSpace(model.Address))
            //     throw new System.Exception("Fields are not filled properly");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                // Send request to the backend service to place the order.
                // Get response and process it.
                string response = _clientController.PrepareMealExecute(model);
                // 
                preparingOrderMsg = "The order was successfully placed";
            }
        }
        catch (System.Exception ex)
        {
            preparingOrderMsg = "ERROR: " + ex.Message;
        }
        return Json(new {
            Message = preparingOrderMsg
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
