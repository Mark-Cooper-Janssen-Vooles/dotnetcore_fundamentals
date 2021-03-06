﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                // var greeting = configuration["Greetng"];
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //  /home/index/4 to home controllers index action
            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
