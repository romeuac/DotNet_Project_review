using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Romeu_Project.Services
{
    public interface IMyInjectedService
    {
        Guid MyGuid { get; set; }
    }

    // Tipicamente o texto abaixo deve vir em um arquivo separado ao da interface
    public class MyInjectedService : IMyInjectedService
    {
        public Guid MyGuid { get; set; }

        public MyInjectedService()
        {
            this.MyGuid = Guid.NewGuid();
        }

    }
}
