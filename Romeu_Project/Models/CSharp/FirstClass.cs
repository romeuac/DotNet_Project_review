using System;

namespace Romeu_Project.Models.CSharp
{
    public class FirstClass
    {
        public string Value;

        private string _value;

        private string cor;
        public string Cor { get => cor; set => cor = value; }

        // Properties
        public string MainValue{
            get => MainValue;
            set => MainValue = value;
        }

        public FirstClass(){}

    }
}
