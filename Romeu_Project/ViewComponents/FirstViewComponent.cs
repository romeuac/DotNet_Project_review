using Microsoft.AspNetCore.Mvc;
using Romeu_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Romeu_Project.ViewComponents
{
    public class FirstViewComponent : ViewComponent
    {
        private IMyInjectedService myService;

        public FirstViewComponent(IMyInjectedService service)
        {
            myService = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // LEMBRAR DE EVOCAR TODOS OS VIEWS COMPONENTES DE maneira ASSINCRONA
            var myItem = await GetGuid();
            return View("Default", myItem);
        }

        private async Task<IMyInjectedService> GetGuid()
        {
            return await Task.FromResult(myService);
        }

    }
}
