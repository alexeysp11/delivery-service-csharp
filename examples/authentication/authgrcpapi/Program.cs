using DeliveryService.Examples.Common;

// Arrange 
var hostname = "https://localhost:7225"; 
var requestCount = 500;
// Act 
var client = new GrpcClient();
var timeInfo = await client.AnalizeAuthGrcpApiClientAsync(hostname, requestCount); 
// 
System.Console.WriteLine($"Executed in: {timeInfo.TimeDifferenceString}"); 
