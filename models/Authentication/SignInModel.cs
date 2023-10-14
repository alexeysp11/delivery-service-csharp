namespace DeliveryService.Models.Authentication;

/// <summary>
/// 
/// </summary>
public class SignInModel
{
    /// <summary>
    /// User login.
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// User password.
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Shows if the site needs to send a cookie that enables a persistent session.
    /// </summary>
    public bool KeepLoggedIn { get; set; }
}
