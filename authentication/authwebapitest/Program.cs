using System.Collections.Generic;
using Cims.WorkflowLib.NetworkApis;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Models.Performance;
using DeliveryService.Authentication.AuthWebApi;

namespace PublicTransportDevices.Examples;

class Program
{
    static async Task Main(string[] args)
    {
        var httpSender = new HttpSender();
        var responses = await httpSender.SendMultipleAsync(
            "https://localhost:7251/GetTokenByUserUid", 
            new List<object>
            {
                new
                {
                    Login = "string",
                    Password = "string"
                }
            },
            "HttpSender.SendMultipleAsync");
        var executionTime = responses[0].ExecutionTime;
        System.Console.WriteLine($"Method: {responses[0].MethodName}");
        System.Console.WriteLine($"Request: {responses[0].Request}");
        System.Console.WriteLine($"Response: {responses[0].Response}");
        System.Console.WriteLine($"Started: {executionTime.DateTimeBegin}");
        System.Console.WriteLine($"Finished: {executionTime.DateTimeEnd}");
        System.Console.WriteLine($"Executed in: {executionTime.TimeDifference.Seconds}:{executionTime.TimeDifference.Milliseconds}");
    }
}
