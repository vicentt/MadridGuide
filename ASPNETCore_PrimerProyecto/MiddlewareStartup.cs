using MadridGuide.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MadridGuide
{
    public class MiddlewareStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddTransient<MyTimingMiddleware>();
            services.AddSingleton<IMadridGuide, MadridGuideClass>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/rutaAlternativa", appBuilder => {
                appBuilder.Run(async context =>
                {
                    await context.Response.WriteAsync("Branch!!!");
                });
            });

            app.MapWhen(context => context.Request.Headers.ContainsKey("AtletiCampeon"), appBuilder => {
                appBuilder.Run(async context =>
                {
                    await context.Response.WriteAsync("AtletiCampeon!!!");
                });
            });

            app.UseMiddleware<ExceptionHandler>();
            app.UseMiddleware<MyTimingMiddlewareChung>();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Entrando en middleware1");
                context.Response.Headers.Add("Middleware", "valor1");
                await next.Invoke();
                Console.WriteLine("Saliendo de middleware1");

            });

            app.Run(async context =>
            {
                //  await context.Response.WriteAsync("Hola Desarrollo");
                var MadridGuide = context.RequestServices.GetService<IMadridGuide>();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(MadridGuide.GetPlacesOfInterest()));
            });
        }
    }

    public class MyTimingMiddlewareChung 
    {
        private readonly RequestDelegate next;

        public MyTimingMiddlewareChung(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //throw new Exception("Excepcion de MD");
            Console.WriteLine($"Entro contador");
            var stopwatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopwatch.Stop();
            Console.WriteLine($"Tiempo transcurrido {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }

    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception error)
            { Console.WriteLine($"Esto es un error de MD : {error.Message}"); }
        }
    }





    //public class MyTimingMiddleware : IMiddleware
    //{
    //    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    //    {
    //        var stopwatch = Stopwatch.StartNew();
    //        await next.Invoke(context);
    //        stopwatch.Stop();
    //        Console.WriteLine($"Tiempo transcurrido {stopwatch.ElapsedMilliseconds} milliseconds");
    //    }
    //}
}
