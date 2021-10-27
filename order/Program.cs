using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using order.infrastructure.Data;

namespace order
{
    public class Program
    {
        public  static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            using(var scoope=host.Services.CreateScope())
            {
                var service = scoope.ServiceProvider;
                var loggerfa = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var ordercontext = service.GetRequiredService<OrderContext>();
                   OrderContextSeed.seedAsync(ordercontext, loggerfa);
                }
                catch( Exception e)
                {
                    var log = loggerfa.CreateLogger<Program>();
                    log.LogError(e.Message);


                }

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
