using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FuncHttp
{
    public static class Books
    {
        [FunctionName("Books")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // ���Ѓf�[�^��Ԃ�
            var books = new List<Book>()
            {
                new Book { Id = 1, Title = ".NET 5 ���", Author = "���c�q��", Price = 2000, Publisher = "���oBP"},
                new Book { Id = 2, Title = "Blazor ����", Author = "���c�q��", Price = 2000, Publisher = "���oBP"},
                new Book { Id = 3, Title = "�s�[�v���E�F�A", Author = "�g���E�f�}���R", Price = 2000, Publisher = "���oBP"},
                new Book { Id = 4, Title = "�l���̐_�b", Author = "�u���b�N�X", Price = 2000, Publisher = "�s�A�\���E�G�f���P�[�V����"},
                new Book { Id = 5, Title = "�m���n�����", Author = "�쒆�莟�Y", Price = 3000, Publisher = "���m�o��"},
                new Book { Id = 6, Title = "�p�^���E�����Q�[�W", Author = "C�E�A���O�U���_�[", Price = 5000, Publisher = "�����o�ŉ�"},
            };
            var json = JsonConvert.SerializeObject(books);
            return new OkObjectResult(json);
        }
    }
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
    }
}

