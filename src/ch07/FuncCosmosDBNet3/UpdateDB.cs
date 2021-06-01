using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncCDB
{
    public static class UpdateDB
    {
        [FunctionName("UpdateDB")]
        public static void Run([CosmosDBTrigger(
            databaseName: "SampleDB",
            collectionName: "SampleNet",
            ConnectionStringSetting = "COSMOSDB_CONNECTION",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
