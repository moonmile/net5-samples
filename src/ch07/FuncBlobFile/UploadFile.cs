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
                // �Z������ǂݍ���
                var id = sh.Cell(1, 2).Value;      // �Ј��ԍ�
                var person = sh.Cell(2, 2).Value;  // �Ј���
                var section = sh.Cell(3, 2).Value; // ������
                logger.LogInformation($" �Ј��o�^: {id} {person} {section} \n");
                // �����Ńf�[�^�x�[�X��������
            }
        }
    }
}
