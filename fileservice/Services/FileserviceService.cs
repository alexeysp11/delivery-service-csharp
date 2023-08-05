using Grpc.Core;
using DeliveryService.Fileservice;
using DeliveryService.Models.Protos; 

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
        return Task.FromResult(new FileserviceResponse
        {
            SessionTokenUid = request.SessionTokenUid,
            CreatedFileUid = System.Guid.NewGuid().ToString(),
            AttachmentFileType = request.AttachmentFileType,
            FileBytes = request.Values
        });
    }
}
