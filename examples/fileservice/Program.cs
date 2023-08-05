using DeliveryService.Examples.Common;
using DeliveryService.Models.Protos; 

// Arrange 
var hostname = "https://localhost:7083"; 
var requestCount = 1000; 
var tasks = new Task[requestCount]; 
var requests = new FileserviceRequest[requestCount]; 
for (int i = 0; i < requestCount; i++)
{
    requests[i] = new FileserviceRequest 
    {
        SessionTokenUid = System.Guid.NewGuid().ToString(), 
        AttachmentFileType = "PDF", 
        Values = System.Guid.NewGuid().ToString()
    };
}
// Act 
var client = new GrpcClient();
var timeInfo = await client.AnalizeGreeterClientAsync(hostname, requests); 
// 
System.Console.WriteLine($"Executed in: {timeInfo.TimeDifferenceString}"); 
