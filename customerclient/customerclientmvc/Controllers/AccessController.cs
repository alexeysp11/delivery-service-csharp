using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CustomerClientMVC.Models;

namespace CustomerClientMVC.Controllers;

public class AccessController : Controller
{
    private readonly ILogger<AccessController> _logger;

    public AccessController(ILogger<AccessController> logger)
    {
        _logger = logger;
    }

    public IActionResult SignIn()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInModel signInModel)
    {
        if (signInModel.Login == "user" && signInModel.Password == "123")
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, signInModel.Login),
                new Claim("OtherProperties", "Example role")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = signInModel.KeepLoggedIn
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return RedirectToAction("Index", "Home");
        }
        ViewData["ValidationMessage"] = "Incorrect login or password";
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }
}