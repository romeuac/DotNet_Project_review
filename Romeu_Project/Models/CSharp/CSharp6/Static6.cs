using System;
using static System.Console;


namespace Romeu_Project.Models.CSharp.CSharp6
{
    public static class Static6
    {
        
        public static void FirstStaticMethod()
        {
            // C# 5 below Statics
            Console.WriteLine("Text");

            // # 6 Statics - devido ao using static System.Console
            WriteLine();


            // String interpolation
            string first = "Eu ";
            string scnd = "Voce  ";
            // C# 5
            Console.WriteLine("{0} quero, {1} quer", first, scnd);

            // C# 6
            WriteLine($"{first} quero, {1} quer");



        }
    }
}
