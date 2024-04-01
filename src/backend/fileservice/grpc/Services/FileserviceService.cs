using System.Collections.Generic;
using Grpc.Core;
using Google.Protobuf;
using WorkflowLib.Models.Documents;
using WorkflowLib.Models.Documents.Enums;
using DeliveryService.Fileservice;
using DeliveryService.Models.Protos;
using DeliveryService.Backend.FileService.BL.Controllers;
using FileserviceRequestModel = DeliveryService.Models.FileserviceRequest;
using FileserviceResponseModel = DeliveryService.Models.FileserviceResponse;

namespace DeliveryService.Fileservice.Services;

public class FileserviceService : DeliveryService.Models.Protos.Fileservice.FileserviceBase
{
    private readonly ILogger<FileserviceService> _logger;
    public FileserviceService(ILogger<FileserviceService> logger)
    {
        _logger = logger;
    }

    public override Task<FileserviceResponse> GetFile(FileserviceRequest request, ServerCallContext context)
    {
        // Get attachment file type
        AttachmentFileType attachmentFileType;
        // if (System.Enum.TryParse<AttachmentFileType>(request.AttachmentFileType, true, out attachmentFileType) == false)
        //     attachmentFileType = AttachmentFileType.JSON;
        // Convert ByteString to the object, that represents elements to convert
        // object objValues;
        // using(MemoryStream ms = new MemoryStream(request.Values.ToStringUtf8()))
        //     objValues = new BinaryFormatter().Deserialize(ms);
        // Get request model
        var requestModel = new FileserviceRequestModel
        {
            SessionTokenGuid = new System.Guid(request.SessionTokenGuid),
            // AttachmentFileType = attachmentFileType,
            Values = System.Text.Json.JsonSerializer.Deserialize<List<WorkflowLib.Models.Documents.TextDocElement>>(request.Values.ToStringUtf8())
        };
        // Get response model 
        var responseModel = new FileConverter().GetFile(requestModel);
        return Task.FromResult(new FileserviceResponse
        {
            SessionTokenGuid = responseModel.SessionTokenGuid.ToString(),
            CreatedFileGuid = responseModel.CreatedFileGuid.ToString(),
            AttachmentFileType = responseModel.AttachmentFileType.ToString(),
            FileBytes = ByteString.CopyFrom(responseModel.FileBytes),
            ExceptionDetails = responseModel.ExceptionDetails
        });
    }
}
