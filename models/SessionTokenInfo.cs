using DeliveryService.Models.Enums; 

namespace DeliveryService.Models;

/// <summary>
/// Represents session token: generated GUID, begin/end of token 
/// </summary>
public class SessionTokenInfo
{
    public System.Guid SessionTokenGuid { get; set; }
    public System.DateTime TokenActivityBegin { get; set; }
    public System.DateTime TokenActivityEnd { get; set; }
}