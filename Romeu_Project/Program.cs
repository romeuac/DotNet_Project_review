using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Romeu_Project
{
    public class Program
    {
        // Eh a ENTRADA da aplicacao
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                // Permitimos que use Kestrel como servidor a ser usado como o web host
                .UseKestrel()
                // Usa o caminho de conteúdo do Root pegando o diretorio atual da aplicacao
                .UseContentRoot(Directory.GetCurrentDirectory())
                // Usando integracao IIS 
                .UseIISIntegration()
                // Usa o Startup que configura-se no outro arquivo Startup.cs
                .UseStartup<Startup>()
                .UseApplicationInsights()
                // Build a aplicacao
                .Build();

            host.Run();
        }
    }
}
