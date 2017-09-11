using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaFilme.Models;
using LocaFilme.ViewModels;

namespace LocaFilme.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        //[Route("Customers/Details/{givenId:regex(\\d{1}):range(1,2)}")]
        //public ActionResult Details(int givenId)
        //{
        //    //var model = new Customer() { Id = givenId, Name = "none"};

        //    var movie = new Movie() { Name = "Sherek!" };

        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1", Id = givenId},
        //        new Customer {Name = "Customer 2", Id = givenId}
        //    };

        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}
        [Route("Customers/Details/{id:regex(\\d{1}):range(1,2)}")]
        public ActionResult Details(int id)
        {
            
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                    return HttpNotFound();

            return View(customer);
            
        }

    
    }
}