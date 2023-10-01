using WokflowLib.Authentication.Models.ConfigParameters;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace DeliveryService.Authentication.AuthWebApi.AuthBL;

public class AuthResolver
{
    private CheckUCConfig CheckUCConfig { get; set; }

    public AuthResolver()
    {
        CheckUCConfig = ConfigHelper.GetUCConfigs();
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
            response.ExceptionMessage = ex.ToString();
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
            new UserResolver().AddUser(request, response);
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
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
            response.ExceptionMessage = ex.ToString();
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
            response.ExceptionMessage = ex.ToString();
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
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }
}