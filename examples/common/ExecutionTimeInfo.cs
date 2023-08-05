namespace DeliveryService.Examples.Common;

public class ExecutionTimeInfo
{
    public System.DateTime Start { get; set; }
    public System.DateTime End { get; set; }
    public System.TimeSpan TimeDifference { get { return End - Start; } }
    public string TimeDifferenceString 
    {
        get 
        {
            var dif = TimeDifference; 
            return $"{System.Math.Floor(dif.TotalDays)}:{dif.Hours}:{dif.Minutes}:{dif.Seconds}:{dif.Milliseconds}"; 
        }
    }
}
