namespace DeliveryService.Models.Authentication;

/// <summary>
/// 
/// </summary>
public class SignInModel
{
    /// <summary>
    /// 
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool KeepLoggedIn { get; set; }
}
