using Basket.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    public class BasketContext:DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        { 
        }
        public DbSet<BasketCart> baskets { get; set; }
    }
}
