using Cims.WorkflowLib.Models.Documents.Enums; 

namespace DeliveryService.Models; 

/// <summary>
/// Represents the request to the file service, that has the following 
/// output parameters: session token UID, UID of the created file, file type, byte representation of the file, 
/// exception details.
/// </summary>
public class FileserviceResponse
{
    /// <summary>
    /// 
    /// </summary>
    public System.Guid SessionTokenGuid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public System.Guid CreatedFileGuid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public AttachmentFileType AttachmentFileType { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public byte[] FileBytes { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string ExceptionDetails { get; set; }
}