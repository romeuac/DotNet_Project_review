using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaFilme.Models;
using LocaFilme.ViewModels;

namespace LocaFilme.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            // Passando data para a View por Dicionario - NAO RECOMENDADO
            //ViewData["Movie"] = movie;
            //return View();

            //return View(movie);
        }

        // Da maneira abaixo tem-se de passar 2 digitols para o month e de 1 a 12
        [Route("Movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("Movies/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}