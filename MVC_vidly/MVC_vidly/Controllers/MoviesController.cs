using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_vidly.Models;
using MVC_vidly.ViewModels;

namespace MVC_vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Home Alone"},
                new Movie {Name = "Christmas Vacation"}
            };
            return View(movies);
        }
        // GET: Movies/Random
        public ActionResult Random()  //or public ViewResult Random()
        {
            var movie = new Movie(){Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return View(movie);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }   
        // GET: movies/edit/1 or movies/edit?id=1
        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }
        public ActionResult Index(int? pageIndex, string sortBy)  //int? make pageIndex nullable
        {
            if(!pageIndex.HasValue) {
                pageIndex = 1;
            }
            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}