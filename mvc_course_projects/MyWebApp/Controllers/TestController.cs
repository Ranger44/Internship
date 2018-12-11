using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers {
    public class TestController : Controller {
        public IActionResult Foo() {
            ViewData["Title"] = "Foo";
            ViewData["Header"] = "Header Foo";
            ViewData["Items"] = "AAA BBB CCC".Split(' ');
            return View();
        }
        public IActionResult Bar() {
            ViewBag.Title = "Bar";
            ViewBag.Header = "Header Bar";
            ViewBag.Items = "DDD EEE FFF".Split(' ');
            return View();
        }
    }
}