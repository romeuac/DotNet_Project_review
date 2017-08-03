using System;
using Romeu_Project.Models.Interface;

namespace Romeu_Project.Models.CSharp
{
    // Interfaces são bem mais simples do que classes. Elas não tem atributos e seus métodos não tem implementação.
    // A interface apenas nos garante que o método existirá naquela classe. 
    // Por esse motivo, apesar de C# não suportar herança múltipla (ser filho de mais de uma classe), 
    // podemos implementar quantas interfaces quisermos. Basta colocar uma na frente da outra
    public class MyInterface : IInterface
    {
        private double amount;

        private string str;

        public MyInterface()
        {
            amount = 10;
            str = "Romeuuu";
        }

        public double GetValue()
        {
            return amount;
        }

        public void ShowValue()
        {
            Console.WriteLine($"Meu nome é {str}");
        }
    }

    public class MyInterface2 : IInterface
    {


        public double GetValue()
        {
            throw new NotImplementedException();
        }

        public void ShowValue()
        {
            throw new NotImplementedException();
        }
    }
}
