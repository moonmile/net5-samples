using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiDB.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
    }
}
