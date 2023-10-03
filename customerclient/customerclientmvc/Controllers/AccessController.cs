using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CustomerClientMVC.Models;
using Cims.WorkflowLib.NetworkApis;
using WokflowLib.Authentication.Models.NetworkParameters;

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
            var request = new UserCredentials
            {
                Login = signInModel.Login,
                Password = signInModel.Password
            };
            var responseStr = new HttpSender().Send("https://localhost:7252/AuthWebApi/VerifyUserCredentials", request);
            System.Console.WriteLine("responseStr: " + responseStr);
            var response = JsonSerializer.Deserialize<VUCResponse>(responseStr, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            // 
            if (response.WorkflowException != null && !string.IsNullOrWhiteSpace(response.WorkflowException.Message))
                throw new System.Exception(response.WorkflowException.Message);
            if (!string.IsNullOrWhiteSpace(response.ExceptionMessage))
                throw new System.Exception(response.ExceptionMessage);
            if (!response.IsVerified)
                throw new System.Exception("Incorrect login or password");
            // 
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
            var request = new UserCredentials
            {
                Login = signUpModel.Login,
                Email = signUpModel.Email,
                PhoneNumber = signUpModel.PhoneNumber,
                Password = signUpModel.Password
            };
            var responseStr = new HttpSender().Send("https://localhost:7252/AuthWebApi/AddUser", request);
            var response = JsonSerializer.Deserialize<UserCreationResult>(responseStr, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            // 
            if (response.WorkflowException != null && !string.IsNullOrWhiteSpace(response.WorkflowException.Message))
                throw new System.Exception(response.WorkflowException.Message);
            if (!string.IsNullOrWhiteSpace(response.ExceptionMessage))
                throw new System.Exception(response.ExceptionMessage);
            if (response.UserExistanceBefore != null && response.UserExistanceBefore.LoginExists)
                throw new System.Exception("User with the specified login already exists");
            if (!response.IsUserAdded)
                throw new System.Exception("Unable to add user");
            // 
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