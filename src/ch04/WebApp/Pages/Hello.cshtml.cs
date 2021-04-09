using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class HelloModel : PageModel
    {

        public string Name { get; set; }
        public DateTime Now { get; set; }
        public void OnGet()
        {

            this.Name = "Masuda Tomoaki";
            this.Now = DateTime.Now;
        }
    }
}
