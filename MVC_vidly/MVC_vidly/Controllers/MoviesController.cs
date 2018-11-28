using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_vidly.Models;

namespace MVC_vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()  //or public ViewResult Random()
        {
            var movie = new Movie(){Name = "Shrek!"};
            //return View(movie);
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }
    }
}