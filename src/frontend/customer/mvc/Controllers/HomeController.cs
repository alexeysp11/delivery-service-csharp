using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using DeliveryService.Frontend.Customer.BL.Controllers;
using DeliveryService.Frontend.Customer.BL.Models;

namespace DeliveryService.Frontend.Customer.Mvc.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CustomerClientControllerBL _clientController;

    public HomeController(
        ILogger<HomeController> logger,
        CustomerClientControllerBL clientController)
    {
        _logger = logger;
        _clientController = clientController;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Account()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["login"] = claimUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["email"] = claimUser.FindFirst(ClaimTypes.Email).Value;
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    public IActionResult MakeOrder()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult MakeOrder(InitialOrder model)
    {
        string placingOrderMsg = string.Empty;
        try
        {
            if (model == null || string.IsNullOrWhiteSpace(model.City) || string.IsNullOrWhiteSpace(model.Address))
                throw new System.Exception("Fields are not filled properly");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                // Send request to the backend service to place the order.
                // Get response and process it.
                string response = _clientController.MakeOrderRequest(model);
                // 
                placingOrderMsg = "The order was successfully placed";
            }
        }
        catch (System.Exception ex)
        {
            placingOrderMsg = "ERROR: " + ex.Message;
        }
        return Json(new {
            Message = placingOrderMsg
        });
    }

    public IActionResult MakePaymentRespond()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
        {
            // ViewData["phone_number"] = claimUser.FindFirst(ClaimTypes.MobilePhone).Value;
        }
        return View();
    }

    [HttpPost]
    public IActionResult MakePaymentRespond(DeliveryOrder model)
    {
        string payingOrderMsg = string.Empty;
        try
        {
            // if (model == null || string.IsNullOrWhiteSpace(model.City) || string.IsNullOrWhiteSpace(model.Address))
            //     throw new System.Exception("Fields are not filled properly");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                // Send request to the backend service to place the order.
                // Get response and process it.
                string response = _clientController.MakePaymentRespond(model);
                // 
                payingOrderMsg = "The order was successfully placed";
            }
        }
        catch (System.Exception ex)
        {
            payingOrderMsg = "ERROR: " + ex.Message;
        }
        return Json(new {
            Message = payingOrderMsg
        });
    }

    public IActionResult AllOrders()
    {
        return View();
    }

    public IActionResult PendingOrders()
    {
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }

    public IActionResult Notifications()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> SignOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("SignIn", "Access");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
