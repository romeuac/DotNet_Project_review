using Microsoft.AspNetCore.Mvc;
using Romeu_Project.Models.CSharp;
using System;
using static Romeu_Project.Models.CSharp.CSharp6.Static6;
//using Romeu_Project.Models.CSharp.CSharp6;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Romeu_Project.Controllers
{
    public class MainController : Controller
    {
        // GET: /<controller>/

        // First instance
        //FirstClass fc = new FirstClass();

        // Second instance
        //private readonly FirstClass _sc;

        //public FirstClass Fc { get => fc; set => fc = value; }

        private string FirstName { get; } = "Romeu";
        private string LastName { get; } = "Andrade";

        // Lambda expression for a variable
        public string FullName => FirstName + " " + LastName;

        // Lambda fucntion
        public double Soma(double a, double b) => a + b;


        public IActionResult Index()
        {
            // Static Class Method CSharp6 - nao precisa utilizar classe devido ao using static Romeu_Pr....Static6
            // que esta acima, justo por termnos colocado o static
            //Static6.FirstStaticMethod();
            //FirstStaticMethod();

            FirstClass fc = new FirstClass();
            fc.Cor = "Rosa"; // ("Main Value - main controller");
            Console.WriteLine("Testeee");

            ViewBag.value = $"My First MVC!!!Cor: {fc.Cor}";
            return View();
        }
    }
}
