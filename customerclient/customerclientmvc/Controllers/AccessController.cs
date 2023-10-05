using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CustomerClientBL;
using CustomerClientBL.Models;
using Cims.WorkflowLib.Models.AppSettings;

namespace CustomerClientMVC.Controllers;

public class AccessController : Controller
{
    private readonly ILogger<AccessController> _logger;
    private readonly NetworkAppSettings _settings;

    public AccessController(ILogger<AccessController> logger, NetworkAppSettings settings)
    {
        _logger = logger;
        _settings = settings;
    }

    public IActionResult SignIn()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInModel signInModel)
    {
        try
        {
            if (_settings.Environment != "test")
                new AccessResolver().SignIn(signInModel);
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
        catch (System.Exception ex)
        {
            ViewData["ValidationMessage"] = "Error: " + ex;
        }
        return View();
    }

    public IActionResult SignUp()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser != null && claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(SignUpModel signUpModel)
    {
        try
        {
            if (_settings.Environment != "test")
                new AccessResolver().SignUp(signUpModel);
            ViewData["ValidationMessage"] = "User has been added successfully";
            return RedirectToAction("SignIn", "Access");
        }
        catch (System.Exception ex)
        {
            ViewData["ValidationMessage"] = "Error: " + ex.Message;
        }
        return View();
    }
}