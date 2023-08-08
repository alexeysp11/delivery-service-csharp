using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using DeliveryService.Models.Protos;

namespace DeliveryService.Examples.Common; 

public class GrpcClient
{
    /// <summary>
    /// 
    /// </summary>
    public async Task<ExecutionTimeInfo> AnalizeFileserviceClientAsync(string hostname, FileserviceRequest[] requests)
    {
        if (string.IsNullOrEmpty(hostname))
            throw new System.Exception("Hostname could not be null or empty"); 
        if (requests.Length == 0)
            throw new System.Exception("Number of request could not be equal to 0"); 
        // 
        var tasks = new List<Task>(); 
        foreach (var request in requests)
        {
            var task = Task.Run(async () => {
                using var channel = GrpcChannel.ForAddress(hostname);
                var reply = await new Fileservice.FileserviceClient(channel).GetFileAsync(request);
                await channel.ShutdownAsync();
            });
            tasks.Add(task); 
        }
        // Excecute and get the time difference 
        ExecutionTimeInfo eti = new ExecutionTimeInfo(); 
        eti.Start = System.DateTime.Now; 
        await Task.WhenAll(tasks.ToArray()); 
        eti.End = System.DateTime.Now; 
        return eti; 
    }
    /// <summary>
    /// 
    /// </summary>
    public async Task<ExecutionTimeInfo> AnalizeAuthGrcpApiClientAsync(string hostname, int requestCount)
    {
        if (string.IsNullOrEmpty(hostname))
            throw new System.Exception("Hostname could not be null or empty"); 
        if (requestCount == 0)
            throw new System.Exception("Number of request could not be equal to 0"); 
        // 
        var tasks = new List<Task>(); 
        for (int i = 0; i < requestCount; i++)
        {
            var task = Task.Run(async () => {
                using var channel = GrpcChannel.ForAddress(hostname);
                var client = new AuthGrpcApi.AuthGrpcApiClient(channel);
                var replyCreate = await client.CreateTokenAsync(new Empty());
                var requestGet = new TokenRequest
                {
                    SessionTokenGuid = replyCreate.SessionTokenGuid
                };
                var replyGet = client.GetTokenByGuidAsync(requestGet);
                await channel.ShutdownAsync();
            });
            tasks.Add(task); 
        }
        // Excecute and get the time difference 
        ExecutionTimeInfo eti = new ExecutionTimeInfo(); 
        eti.Start = System.DateTime.Now; 
        await Task.WhenAll(tasks.ToArray()); 
        eti.End = System.DateTime.Now; 
        return eti; 
    }
}
