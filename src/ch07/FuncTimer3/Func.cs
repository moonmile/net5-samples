using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncTimer3
{
    public static class Func
    {
        [FunctionName("Func")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            log.LogInformation($"Last timer schedule at: {myTimer.ScheduleStatus.Last}");
            log.LogInformation($"LastUpdated timer schedule at: {myTimer.ScheduleStatus.LastUpdated}");
        }
    }
}
