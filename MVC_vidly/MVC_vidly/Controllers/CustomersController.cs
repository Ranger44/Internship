using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_vidly.Models;
using MVC_vidly.ViewModels;

namespace MVC_vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer() {Name = "John Smith"},
                new Customer() {Name = "Mary Williams"}
            };

            return View(customers);
            //return Content(String.Format("customers page"));
        }
    }
}