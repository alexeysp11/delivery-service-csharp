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
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    public IActionResult DecreaseProductQuantity(int productId)
    {
        return RedirectToAction("MakeOrder", "Home");
    }

    public IActionResult IncreaseProductQuantity(int productId)
    {
        return RedirectToAction("MakeOrder", "Home");
    }
}