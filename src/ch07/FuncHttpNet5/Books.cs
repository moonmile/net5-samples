using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace FuncHttpNet5
{
    public static class Books
    {
        [Function("Books")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
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
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(books);
            return response;
        }

        [Function("Book")]
        public static HttpResponseData RunById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Book/{id:int}")] HttpRequestData req,
            int id,
            FunctionContext executionContext)
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
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(books.FirstOrDefault(t => t.Id == id));
            return response;
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
