using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncTimer
{
    public static class TimerExample
    {
        [Function("TimerExample")]
        public static void Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer, FunctionContext context)
        {
            var logger = context.GetLogger("TimerExample");
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            logger.LogInformation($"Last timer schedule at: {myTimer.ScheduleStatus.Last}");
            logger.LogInformation($"LastUpdated timer schedule at: {myTimer.ScheduleStatus.LastUpdated}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
