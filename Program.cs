using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hoor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
                //todo: by k1
                .ConfigureLogging(Logging=>{
                    Logging.ClearProviders();
                    Logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //todo: by k1
                    //webBuilder.UseStartup<MyStartup>();
                    webBuilder.UseStartup<Startup>();
                    //todo: by k1
                    webBuilder.UseWebRoot("Public");
                });
    }
}
