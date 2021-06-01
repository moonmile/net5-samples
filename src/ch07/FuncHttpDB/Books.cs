using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;


namespace FuncHttpDB
{
    public static class Books
    {
        [Function("Books")]
        public static async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Books");
            var cnstr = System.Environment.GetEnvironmentVariable("DB_CONNECTION");
            var builder = new DbContextOptionsBuilder<BooksContext>();
            builder.UseSqlServer(cnstr);
            builder.EnableServiceProviderCaching(false);
            var context = new BooksContext(builder.Options);
            var items = await context.Books.ToListAsync();
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(items);
            return response;
        }

        [Function("Book")]
        public static async Task<HttpResponseData> RunByTitle(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            // BodyからJSON形式で取得
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string title = data?.title;
            // クエリの利用
            if (title == null)
            {
                title = executionContext.BindingContext.BindingData["title"] as string;
            }

            var cnstr = System.Environment.GetEnvironmentVariable("DB_CONNECTION");
            var builder = new DbContextOptionsBuilder<BooksContext>();
            builder.UseSqlServer(cnstr);
            builder.EnableServiceProviderCaching(false);
            var context = new BooksContext(builder.Options);
            var items = await context.Books
                .Where(t => t.Title.Contains(title))
                .ToListAsync();
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(items);
            return response;
        }
    }

    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
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
