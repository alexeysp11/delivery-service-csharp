using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.CustomerClientBL.Models;
using DeliveryService.Models.Orders;

namespace DeliveryService.CustomerClientMVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
    public IActionResult MakeOrder(PlaceOrderModel model)
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
