using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        //static void main is the entry point for the webapi when you go 'dotnet run' from the terminal
        //when visual studio runs this program, but it places "createwebhostbuilder" behind IIS express, which is configured in webHost.createDefaultBuilder

        public static void Main(string[] args)
        {
            //buulds a webhost, passing in any arguments from the command line, then starts running.
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
