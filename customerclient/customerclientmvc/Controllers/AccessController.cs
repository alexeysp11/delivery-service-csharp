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
            // Make request to auth service 
            // 
            bool exists = true;
            if (!exists)
            {
                throw new System.Exception("Incorrect login or password");
            }
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
            ViewData["ValidationMessage"] = "Error occured: " + ex.Message;
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
            // Make request to add user
            // 
            bool isOk = true;
            if (!isOk)
                ViewData["ValidationMessage"] = "Unable to add user: Some error message";
            ViewData["ValidationMessage"] = "User has been added successfully";
            return RedirectToAction("SignIn", "Access");
        }
        catch (System.Exception ex)
        {
            ViewData["ValidationMessage"] = "Error occured: " + ex.Message;
        }
        return View();
    }
}