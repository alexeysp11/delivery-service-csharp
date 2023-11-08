# AccessResolver Class 

Namespace: [DeliveryService.Core.Resolvers](DeliveryService.Core.Resolvers.md)

Access resolver.

## Constructors 

### AccessResolver()

```C#
public AccessResolver();
```

## Methods 

### SignIn(String, SignInModel)

Method for allowing a user to sign in.

```C#
public VUCResponse SignIn(string serverAddress, SignInModel signInModel);
```

#### Parameters 

- `serverAddress`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Server address.

- `signInModel`: [SignInModel](../../models/Authentication/SignInModel.md)

Sign in model.

#### Returns

[VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/VUCResponse.cs)

The result of verification of user credintials.

#### Examples

Example of using `SignIn()` method:

```C#
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
            ...
            return RedirectToAction("Index", "Home");
        }
        catch (System.Exception ex)
        {
            ViewData["ValidationMessage"] = "Error: " + ex.Message;
        }
        return View();
    }
```

### SignUp(String, SignUpModel)

Method for add a user into the database.

```C#
public UserCreationResult SignUp(string serverAddress, SignUpModel signInModel);
```

#### Parameters 

- `serverAddress`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Server address.

- `signInModel`: [SignUpModel](../../models/Authentication/SignUpModel.md)

Sign up model.

#### Returns

[UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/models/NetworkParameters/UserCreationResult.cs)

The result of adding a user to the database.

#### Examples

Example of using `SignUp()` method:

```C#
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
```
