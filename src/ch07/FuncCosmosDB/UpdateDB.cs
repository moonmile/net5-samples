using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncCosmosDB
{
    public static class UpdateDB
    {
        [Function("UpdateDB")]
        public static void Run([CosmosDBTrigger(
            databaseName: "SampleDB",
            collectionName: "SampleNet",
            ConnectionStringSetting = "COSMOSDB_CONNECTION",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)] IReadOnlyList<MyDocument> input, FunctionContext context)
        {
            var logger = context.GetLogger("UpdateDB");
            if (input != null && input.Count > 0)
            {
                logger.LogInformation("Documents modified: " + input.Count);
                logger.LogInformation("First document Id: " + input[0].Id);
            }
        }
    }

    public class MyDocument
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public bool Boolean { get; set; }
    }
}
