using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using order.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.infrastructure.Data
{
    public class OrderContextSeed
    {
        public static  void seedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvaliablity = retry.Value;
            try
            {
                orderContext.Database.Migrate();   //by3ml migration ll database
                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(gtPreconfigOrders());
                     orderContext.SaveChanges();
                }
            }
            catch (Exception e)
            { 
                if(retryForAvaliablity<3)
                {
                    retryForAvaliablity++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(e.Message);
                    seedAsync(orderContext, loggerFactory, retryForAvaliablity);
                }
            }
        }

        private static IEnumerable<Order> gtPreconfigOrders()
        {
            return new List<Order>
           { new Order(){UserName="davidf",FirstName="david", LastName="Mounir",Email="davidf@hitstechnology.com",AddressLine="el daher",Country="cairo",State="cairo"}

           };
        }
    }
}
