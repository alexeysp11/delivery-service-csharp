namespace DeliveryService.Models.Authentication;

/// <summary>
/// Sign up model.
/// </summary>
public class SignUpModel
{
    /// <summary>
    /// User login.
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// User email.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// User phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// User password.
    /// </summary>
    public string? Password { get; set; }
}
