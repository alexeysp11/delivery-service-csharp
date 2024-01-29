using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Frontend.Warehouse.Mvc.Models;
using DeliveryService.Frontend.Warehouse.BL.Controllers;

namespace DeliveryService.Frontend.Warehouse.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private WarehouseClientController _clientController;

    public HomeController(
        ILogger<HomeController> logger,
        WarehouseClientController clientController)
    {
        _logger = logger;
        _clientController = clientController;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RequestStore2WhRespond()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult RequestStore2WhRespond(DeliveryOrder model)
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
                string response = _clientController.RequestStore2WhRespond(model);
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

    public IActionResult ConfirmStore2WhAccept()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult ConfirmStore2WhAccept(DeliveryOrder model)
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
                string response = _clientController.ConfirmStore2WhAccept(model);
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

    public IActionResult Wh2KitchenExecute()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult Wh2KitchenExecute(DeliveryOrder model)
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
                string response = _clientController.Wh2KitchenExecute(model);
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

    public IActionResult Kitchen2WhExecute()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult Kitchen2WhExecute(DeliveryOrder model)
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
                string response = _clientController.Kitchen2WhExecute(model);
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
