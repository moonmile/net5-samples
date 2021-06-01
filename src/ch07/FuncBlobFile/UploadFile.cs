using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ClosedXML.Excel;
using System.Linq;


namespace FuncBlobFile
{
    public static class UploadFile
    {
        [Function("UploadFile")]
        public static void Run(
            [BlobTrigger("samples-workitems/{name}", Connection = "STORAGE_CONNECTION")] ReadOnlyMemory<byte> stBlob, 
            string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("UploadFile");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n");
            using (var st = new MemoryStream(stBlob.ToArray()))
            {
                var wb = new XLWorkbook(st);
                var sh = wb.Worksheets.First();
                // セルから読み込み
                var id = sh.Cell(1, 2).Value;      // 社員番号
                var person = sh.Cell(2, 2).Value;  // 社員名
                var section = sh.Cell(3, 2).Value; // 部署名
                logger.LogInformation($" 社員登録: {id} {person} {section} \n");
                // ここでデータベース書き込み
            }
        }
    }
}
