using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncBlob
{
    public static class UpdateBlob
    {
        [Function("UpdateBlob")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "STORAGE_CONNECTION")] string myBlob, string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("UpdateBlob");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} ");
        }
    }
}
