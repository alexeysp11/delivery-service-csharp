namespace DeliveryService.Models;

/// <summary>
/// Represents session token: generated GUID, begin/end of token.
/// </summary>
public class SessionTokenInfo
{
    /// <summary>
    /// Session token GUID.
    /// </summary>
    public System.Guid SessionTokenGuid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public System.DateTime TokenActivityBegin { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public System.DateTime TokenActivityEnd { get; set; }
}