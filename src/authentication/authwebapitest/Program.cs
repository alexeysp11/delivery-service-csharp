using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WorkflowLib.NetworkAPIs;
using WorkflowLib.Models.Network;
using WorkflowLib.Models.Performance;
using DeliveryService.Authentication.AuthWebApi;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace PublicTransportDevices.Examples;

class Program
{
    static async Task Main(string[] args)
    {
        var httpSender = new HttpSender();
        var response = await httpSender.SendAsync(
            "https://localhost:7251/Auth/AddUser", 
            new
            {
                Login = "user1",
                Password = "pswd"
            },
            "HttpSender.SendAsync");
        var responseDeserialized = JsonSerializer.Deserialize<UserCreationResult>(response.Response);
        System.Console.WriteLine($"IsVerified: {responseDeserialized.IsVerified}");
        System.Console.WriteLine($"UserUid: {responseDeserialized.UserUid}");
        
        var executionTime = response.ExecutionTime;
        System.Console.WriteLine($"Method: {response.MethodName}");
        System.Console.WriteLine($"Request: {response.Request}");
        System.Console.WriteLine($"Response: {response.Response}");
        System.Console.WriteLine($"Started: {executionTime.DateTimeBegin}");
        System.Console.WriteLine($"Finished: {executionTime.DateTimeEnd}");
        System.Console.WriteLine($"Executed in: {executionTime.TimeDifference.Seconds}:{executionTime.TimeDifference.Milliseconds}");

        // var responses = await httpSender.SendMultipleAsync(
        //     "https://localhost:7251/Auth/VerifyUserCredentials", 
        //     new List<object>
        //     {
        //         new
        //         {
        //             Login = "string",
        //             Password = "string"
        //         },
        //         new
        //         {
        //             Login = "user1",
        //             Password = "pswd"
        //         }
        //     },
        //     "HttpSender.SendMultipleAsync");
        // var executionTime = responses[0].ExecutionTime;
        // System.Console.WriteLine($"Method: {responses[0].MethodName}");
        // System.Console.WriteLine($"Request: {responses[0].Request}");
        // System.Console.WriteLine($"Response: {responses[0].Response}");
        // System.Console.WriteLine($"Started: {executionTime.DateTimeBegin}");
        // System.Console.WriteLine($"Finished: {executionTime.DateTimeEnd}");
        // System.Console.WriteLine($"Executed in: {executionTime.TimeDifference.Seconds}:{executionTime.TimeDifference.Milliseconds}");
    }
}
