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
            // 書籍データを返す
            var books = new List<Book>()
            {
                new Book { Id = 1, Title = ".NET 5 解説", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 2, Title = "Blazor 入門", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 3, Title = "ピープルウェア", Author = "トム・デマルコ", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 4, Title = "人月の神話", Author = "ブルックス", Price = 2000, Publisher = "ピアソン・エデュケーション"},
                new Book { Id = 5, Title = "知識創造企業", Author = "野中郁次郎", Price = 3000, Publisher = "東洋経済"},
                new Book { Id = 6, Title = "パタン・ランゲージ", Author = "C・アレグザンダー", Price = 5000, Publisher = "鹿島出版会"},
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
            // 書籍データを返す
            var books = new List<Book>()
        {
            new Book { Id = 1, Title = ".NET 5 解説", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 2, Title = "Blazor 入門", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 3, Title = "ピープルウェア", Author = "トム・デマルコ", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 4, Title = "人月の神話", Author = "ブルックス", Price = 2000, Publisher = "ピアソン・エデュケーション"},
            new Book { Id = 5, Title = "知識創造企業", Author = "野中郁次郎", Price = 3000, Publisher = "東洋経済"},
            new Book { Id = 6, Title = "パタン・ランゲージ", Author = "C・アレグザンダー", Price = 5000, Publisher = "鹿島出版会"},
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
