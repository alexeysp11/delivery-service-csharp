using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomerClientMVC.Models;

namespace CustomerClientMVC.Controllers;

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
        return View();
    }

    public IActionResult MakeOrder()
    {
        return View();
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
