namespace DeliveryService.Models;

/// <summary>
/// Represents the request to the file service, that has the following 
/// input parameters: session token UID, attachment file type, values for creating the file.
/// </summary>
public class FileserviceRequest
{
    public System.Guid SessionTokenGuid { get; set; }
    public AttachmentFileType AttachmentFileType { get; set; }
    public object Values { get; set; }
}
