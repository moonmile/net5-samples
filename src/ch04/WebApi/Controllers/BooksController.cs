using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = ".NET 5 解説", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 2, Title = "Blazor 入門", Author = "増田智明", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 3, Title = "ピープルウェア", Author = "トム・デマルコ", Price = 2000, Publisher = "日経BP"},
            new Book { Id = 4, Title = "人月の神話", Author = "ブルックス", Price = 2000, Publisher = "ピアソン・エデュケーション"},
            new Book { Id = 5, Title = "知識創造企業", Author = "野中郁次郎", Price = 3000, Publisher = "東洋経済"},
            new Book { Id = 6, Title = "パタン・ランゲージ", Author = "C・アレグザンダー", Price = 5000, Publisher = "鹿島出版会"},
        };

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return this.books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return this.books.FirstOrDefault(t => t.Id == id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
