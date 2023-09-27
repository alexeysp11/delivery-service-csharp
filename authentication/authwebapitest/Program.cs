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
            "https://localhost:7251/WeatherForecast", 
            new List<object> 
            {
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = 0,
                    Summary = "TemperatureC"
                }
            },
            "HttpSender.SendMultipleAsync");
        var executionTime = responses[0].ExecutionTime;

        System.Console.WriteLine($"Method: {responses[0].MethodName}");
        System.Console.WriteLine($"Method: {responses[0].Request}");
        System.Console.WriteLine($"Method: {responses[0].Response}");
        System.Console.WriteLine($"Started: {executionTime.DateTimeBegin}");
        System.Console.WriteLine($"Executed: {executionTime.DateTimeEnd}");
        System.Console.WriteLine($"Executed in: {executionTime.TimeDifference.Seconds}:{executionTime.TimeDifference.Milliseconds}");
    }
}
