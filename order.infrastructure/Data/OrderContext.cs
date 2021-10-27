using Microsoft.EntityFrameworkCore;
using order.core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace order.infrastructure.Data
{
     public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { 
        }
      /*
        protected override void OnModelCreating(ModelBuilder objmodel)
        {
            objmodel.Entity<Order>().ToTable("Orders1");
        }*/
    public DbSet<Order> Orders { get; set; }
    }
}
