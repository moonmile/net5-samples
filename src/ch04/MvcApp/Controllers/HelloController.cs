using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            var model = new HelloModel();
            model.Name = "Tomoaki Masuda";
            model.Now = DateTime.Now;
            return View(model);
        }
    }
}
