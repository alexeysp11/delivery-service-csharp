using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.Frontend.Customer.BL.Models;
using Cims.WorkflowLib.Models.Business.Delivery;

namespace DeliveryService.Frontend.Customer.Mvc.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    public IActionResult DecreaseProductQuantity(int productId, int redirect = 0)
    {
        var cartCount = 0; // await _cartRepo.AddItem(bookId, qty);
        if (redirect == 0)
            return Ok(cartCount);
        return RedirectToAction("MakeOrder", "Home");
    }

    public IActionResult IncreaseProductQuantity(int productId, int redirect = 0)
    {
        var cartCount = 0; // await _cartRepo.AddItem(bookId, qty);
        if (redirect == 0)
            return Ok(cartCount);
        return RedirectToAction("MakeOrder", "Home");
    }
}