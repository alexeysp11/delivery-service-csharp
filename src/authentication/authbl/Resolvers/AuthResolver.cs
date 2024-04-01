using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.Models.ConfigParameters;
using WokflowLib.Authentication.Models.NetworkParameters;
using WorkflowLib.Models.ErrorHandling;

namespace DeliveryService.Authentication.AuthWebApi.AuthBL;

/// <summary>
/// 
/// </summary>
public class AuthResolver
{
    /// <summary>
    /// 
    /// </summary>
    private CheckUCConfig CheckUCConfig { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public AuthResolver()
    {
        CheckUCConfig = new ConfigHelper().GetUCConfigs();
    }

    /// <summary>
    /// Checks if specified user exists in the application database (request redirection is needed)
    /// </summary>
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        var response = new UserExistance();
        try
        {
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsEmailRequired && string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (CheckUCConfig.IsPhoneNumberRequired && string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty"); 
            // 
            new UserResolver().CheckUserExistance(request, response);
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }

    public UserCreationResult AddUser(UserCredentials request)
    {
        var response = new UserCreationResult();
        try
        {
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsEmailRequired && string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (CheckUCConfig.IsPhoneNumberRequired && string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty");
            if (CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            response.UserExistanceBefore = CheckUserExistance(request);
            if (response.UserExistanceBefore != null && !response.UserExistanceBefore.LoginExists)
            {
                new UserResolver().AddUser(request, response);
                response.UserExistanceAfter = CheckUserExistance(request);
            }
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }

    public VSUResponse VerifySignUp(VSURequest request)
    {
        var response = new VSUResponse();
        try
        {
            // Decide if the verification was successful based on the token info from request 
            // Add the value into database 
            // 
            response.IsSuccessful = true;
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }

    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        var response = new VUCResponse();
        try
        {
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            new UserResolver().VerifyUserCredentials(request, response);
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }

    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        var response = new SessionToken();
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserUid))
                throw new System.Exception("Parameter 'UserUid' could not be null or empty");
            // Update session token for the specified user 
            // 
            int userId = new UserResolver().GetUserIdByUid(request.UserUid);
            new TokenResolver().CreateToken(userId, response);
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }
}