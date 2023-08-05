using DeliveryService.Models.Enums; 

namespace DeliveryService.Models; 

/// <summary>
/// Represents the request to the file service, that has the following 
/// output parameters: session token UID, UID of the created file, file type, byte representation of the file, 
/// exception details 
/// </summary>
public class FileserviceResponse
{
    public System.Guid SessionTokenGuid { get; set; }
    public System.Guid CreatedFileGuid { get; set; }
    public AttachmentFileType AttachmentFileType { get; set; }
    public byte[] FileBytes { get; set; }
    public string ExceptionDetails { get; set; }
}