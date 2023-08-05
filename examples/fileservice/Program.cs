using Google.Protobuf; 
using Cims.WorkflowLib.Models.Documents;
using Cims.WorkflowLib.Models.Documents.Enums;
using DeliveryService.Examples.Common;
using DeliveryService.Models.Protos;

// Arrange 
var hostname = "https://localhost:7083"; 
var requestCount = 500; 
var tasks = new Task[requestCount]; 
var requests = new FileserviceRequest[requestCount]; 
var elements = new System.Collections.Generic.List<TextDocElement>()
{
    new TextDocElement() 
    {
        Content = "Header 1", 
        FontSize = 50, 
        TextAlignment = TextAlignment.CENTER
    }, 
    new TextDocElement() 
    {
        Content = "Paragraph 1\nLet's print out some content to the paragraph...", 
        FontSize = 14, 
        TextAlignment = TextAlignment.LEFT
    }, 
    new TextDocElement() 
    {
        Content = "Header 2", 
        FontSize = 50, 
        TextAlignment = TextAlignment.CENTER
    }, 
    new TextDocElement() 
    {
        Content = "Paragraph 2\nLet's print out again some content to the paragraph...", 
        FontSize = 14, 
        TextAlignment = TextAlignment.JUSTIFIED
    }
};
for (int i = 0; i < requestCount; i++)
{
    requests[i] = new FileserviceRequest 
    {
        SessionTokenGuid = System.Guid.NewGuid().ToString(),
        AttachmentFileType = "PDF", 
        Values = ByteString.CopyFromUtf8(System.Text.Json.JsonSerializer.Serialize(elements))
    };
}
// Act 
var client = new GrpcClient();
var timeInfo = await client.AnalizeGreeterClientAsync(hostname, requests); 
// 
System.Console.WriteLine($"Executed in: {timeInfo.TimeDifferenceString}"); 
