using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.CustomerClientBL;
using DeliveryService.Models.Authentication;
using Cims.WorkflowLib.Models.AppSettings;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace DeliveryService.CustomerClientMVC.Controllers;

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
            if (signInModel == null || 
                (
                    signInModel != null
                    && string.IsNullOrWhiteSpace(signInModel.Login)
                    && string.IsNullOrWhiteSpace(signInModel.Password)
                ))
            {
                throw new System.Exception("Fields are not filled properly");
            }
            bool isTest = _settings.Environment == "test";
            var response = new VUCResponse();
            if (!isTest)
                response = new AccessResolver().SignIn(_settings.ServerAddress, signInModel);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, signInModel.Login),
                new Claim(ClaimTypes.Email, isTest ? "model.login@example.com" : (response.UserCredentials == null ? "" : response.UserCredentials.Email)),
                new Claim(ClaimTypes.MobilePhone, isTest ? "+136223213242" : (response.UserCredentials == null ? "" : response.UserCredentials.PhoneNumber)),
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
            ViewData["ValidationMessage"] = "Error: " + ex.Message;
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
            if (signUpModel == null || 
                (
                    signUpModel != null
                    && string.IsNullOrWhiteSpace(signUpModel.Login)
                    && string.IsNullOrWhiteSpace(signUpModel.Email)
                    && string.IsNullOrWhiteSpace(signUpModel.PhoneNumber)
                    && string.IsNullOrWhiteSpace(signUpModel.Password)
                ))
            {
                throw new System.Exception("Fields are not filled properly");
            }
            if (_settings.Environment != "test")
                new AccessResolver().SignUp(_settings.ServerAddress, signUpModel);
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