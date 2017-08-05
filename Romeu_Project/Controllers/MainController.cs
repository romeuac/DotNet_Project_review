using Microsoft.AspNetCore.Mvc;
using Romeu_Project.Models;
using Romeu_Project.Services;
using Romeu_Project.ViewModels;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Romeu_Project.Controllers
{
    // Com o parametro abaixo, para abrir a pagina eh necessario digitar /test/ na frente da url
    // [Route("Test")]
    //[Route("[Controller]")]
    public class MainController : Controller
    {
        private IMyInjectedService myService;

        public MainController(IMyInjectedService myService)
        {
            this.myService = myService;
        }

        //[Route("Main")]
        //[Route("[Action]")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.value = "My First MVC!!!";
            ViewBag.myobject = this.myService;
            return View();
        }

        public IActionResult FirstView()
        {
            //var model = new MyData { MyId = 2, MyValue = "My Value" };

            var model = new List<MyData> {
                new MyData { MyId = 1, MyValue = "My Value 1" },
                new MyData { MyId = 2, MyValue = "My Value 2" }
            };

            var viewmodel = new FirstViewViewModel();
            viewmodel.MyType = model;

            return View(viewmodel);
        }

        //[Route("First")]
        //[Route("[Action]")]
        // public string IdRoute()
        public ContentResult IdRoute()
        {
            return Content("Attribute Routing");
        }

        // Return Types
        //[Route("[Action]")]
        // public ObjectResult MyObject()
        public JsonResult MyObject()
        {
            var mymodel = new MyData { MyId = 1, MyValue = "My First Value!!!"  };

            return Json(mymodel);
        }

        public IActionResult Authenticate()
        {
            if (ModelState.IsValid)
            {
                // Mandamos para o actio name = Index e com o LoggedIn Controller
                return RedirectToAction("Index", "LoggedIn");
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
        }

    }
}
