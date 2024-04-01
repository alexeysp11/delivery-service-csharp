using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.Frontend.Courier.Mvc.Models;
using DeliveryService.Frontend.Courier.BL.Controllers;
using WorkflowLib.Models.Business.BusinessDocuments;

namespace DeliveryService.Frontend.Courier.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CourierClientController _clientController;

    public HomeController(
        ILogger<HomeController> logger,
        CourierClientController clientController)
    {
        _logger = logger;
        _clientController = clientController;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Store2WhExecute()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult Store2WhExecute(DeliveryOrder model)
    {
        string requestblMsg = string.Empty;
        try
        {
            // if (model == null || string.IsNullOrWhiteSpace(model.City) || string.IsNullOrWhiteSpace(model.Address))
            //     throw new System.Exception("Fields are not filled properly");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                // Send request to the backend service to place the order.
                // Get response and process it.
                string response = _clientController.Store2WhExecute(model);
                // 
                requestblMsg = "The order was successfully placed";
            }
        }
        catch (System.Exception ex)
        {
            requestblMsg = "ERROR: " + ex.Message;
        }
        return Json(new {
            Message = requestblMsg
        });
    }
    
    public IActionResult DeliverOrderExecute()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult DeliverOrderExecute(DeliveryOrder model)
    {
        string requestblMsg = string.Empty;
        try
        {
            // if (model == null || string.IsNullOrWhiteSpace(model.City) || string.IsNullOrWhiteSpace(model.Address))
            //     throw new System.Exception("Fields are not filled properly");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                // Send request to the backend service to place the order.
                // Get response and process it.
                string response = _clientController.DeliverOrderExecute(model);
                // 
                requestblMsg = "The order was successfully placed";
            }
        }
        catch (System.Exception ex)
        {
            requestblMsg = "ERROR: " + ex.Message;
        }
        return Json(new {
            Message = requestblMsg
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
