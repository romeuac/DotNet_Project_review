using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaFilme.Models;
using LocaFilme.ViewModels;

namespace LocaFilme.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        [Route("Customers/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Customers/Details/{givenId:regex(\\d{1}):range(1,2)}")]
        public ActionResult Details(int givenId)
        {
            //var model = new Customer() { Id = givenId, Name = "none"};

            var movie = new Movie() { Name = "Sherek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1", Id = givenId},
                new Customer {Name = "Customer 2", Id = givenId}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}