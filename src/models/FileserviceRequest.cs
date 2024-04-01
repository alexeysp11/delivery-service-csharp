using WorkflowLib.Models.Documents.Enums;

namespace DeliveryService.Models;

/// <summary>
/// Represents the request to the file service, that has the following 
/// input parameters: session token UID, attachment file type, values for creating the file.
/// </summary>
public class FileserviceRequest
{
    /// <summary>
    /// 
    /// </summary>
    public System.Guid SessionTokenGuid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public AttachmentFileType AttachmentFileType { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public object Values { get; set; }
}