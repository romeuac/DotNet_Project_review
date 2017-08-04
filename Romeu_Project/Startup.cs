using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using Romeu_Project.Services;

namespace Romeu_Project
{
    public class Startup
    {
        // IHostingEnvironment prove informacoes sobre o web host aplication
        public Startup (IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();


        }

        public IConfigurationRoot Configuration { get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            // Servico que estamos adicionando do MYInjectedServices
            // Com Add Singleton  Objeto nao muda quando da o refresh na pagina (eh o mesmo objeto trabalhando 
            //services.AddSingleton<IMyInjectedService, MyInjectedService>();

            // Com AddScoped um objeto nova eh criado para cada request 
            //services.AddScoped<IMyInjectedService, MyInjectedService>();
            // Com o AddTransient, um objeto de servico eh criado sempre que um objeto eh solicitado
            services.AddTransient<IMyInjectedService, MyInjectedService>();

            // Add framework services.
            services.AddMvc();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Main/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            // Funcao utilizada para usar (serve up) os arquivos estaticos, como imagens, css... para 
            //associar os arquivos no wwwroot folder
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();

            // Chamada abaixo esta associada com a funcao abaixo, porem funciona apenas se as settings forem Defaul
            // Ou seja, se estiver utilizando o Home como controller, e nao Main como eh o caso.
            //app.UseMvc(Configurationroute);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });
        }

        //private void Configurationroute(IRouteBuilder obj)
        //{
        //    obj.MapRoute("Default", "[controller=Home}/{action=Index}/[id?}");
        //}
    }
}