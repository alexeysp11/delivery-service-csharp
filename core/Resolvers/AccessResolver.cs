using System.Text.Json;
using System.Text.Json.Serialization;
using Cims.WorkflowLib.NetworkApis;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace DeliveryService.Core.Resolvers;

/// <summary>
/// Access resolver.
/// </summary>
public class AccessResolver
{
    /// <summary>
    /// Method for allowing a user to sign in.
    /// </summary>
    public VUCResponse SignIn(string serverAddress, SignInModel signInModel)
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
        var responseStr = new HttpSender().Send(serverAddress + "VerifyUserCredentials", request);
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
        return response;
    }

    /// <summary>
    /// Method for add a user into the database.
    /// </summary>
    public UserCreationResult SignUp(string serverAddress, SignUpModel signUpModel)
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
        var responseStr = new HttpSender().Send(serverAddress + "AddUser", request);
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
        return response;
    }
}
