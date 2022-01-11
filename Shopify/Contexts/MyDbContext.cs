using Microsoft.EntityFrameworkCore;
using Shopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Contexts
{
    public class MyDbContext :DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> op) : base(op) { }
        public DbSet<OrderModel> Orders { get; set; }
    }
}
