using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WorkflowLib.DocFormats;
using WorkflowLib.DocFormats.Images;
using WorkflowLib.DocFormats.TextBased;
using WorkflowLib.DocFormats.Spreadsheets;
using WorkflowLib.Models.Documents;
using WorkflowLib.Models.Documents.Enums;
using FileserviceRequestModel = DeliveryService.Models.FileserviceRequest; 
using FileserviceResponseModel = DeliveryService.Models.FileserviceResponse; 

namespace DeliveryService.Fileservice; 

/// <summary>
/// Converts the following file formats:
/// images, video, Word, Excel, PDF
/// </summary>
public class FileConverter
{
    /// <summary>
    /// 
    /// </summary>
    public FileserviceResponseModel GetFile(FileserviceRequestModel request)
    {
        // Specify folder and file names
        var filename = "attachment";
        var foldername = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), request.SessionTokenGuid.ToString());
        if (!Directory.Exists(foldername)) 
            Directory.CreateDirectory(foldername);
        // Get file bytes
        string exceptionMsg = string.Empty;
        byte[] fileBytes;
        try
        {
            switch (request.AttachmentFileType)
            {
                case AttachmentFileType.PDF:
                    var elements = (List<TextDocElement>)request.Values;
                    fileBytes = GetPdfBytes(foldername, filename + ".pdf", elements);
                    break;
                default:
                    throw new System.Exception("Incorrect attachment file type");
                    break;
            }
        }
        catch (System.Exception ex)
        {
            exceptionMsg = ex.Message;
            fileBytes = new byte[1];
        }
        // Return the generated file
        return new FileserviceResponseModel
        {
            SessionTokenGuid = request.SessionTokenGuid,
            CreatedFileGuid = System.Guid.NewGuid(),
            AttachmentFileType = request.AttachmentFileType,
            FileBytes = fileBytes,
            ExceptionDetails = exceptionMsg
        };
    }
    /// <summary>
    /// 
    /// </summary>
    private byte[] GetPdfBytes(string foldername, string filename, List<TextDocElement> elements)
    {
        if (string.IsNullOrEmpty(foldername))
            throw new System.Exception("Folder name could not be null or empty");
        if (string.IsNullOrEmpty(filename))
            throw new System.Exception("File name could not be null or empty");
        new PdfConverter().TextDocElementsToDocument(foldername, filename, elements);
        return GetFileBytes(Path.Combine(foldername, filename));
    }
    /// <summary>
    /// 
    /// </summary>
    private byte[] GetFileBytes(string filepath)
    {
        if (string.IsNullOrEmpty(filepath))
            throw new System.Exception("File path could not be null or empty");
        if (!File.Exists(filepath))
            throw new System.Exception("File does not exist");
        return File.ReadAllBytes(filepath);
    }
}