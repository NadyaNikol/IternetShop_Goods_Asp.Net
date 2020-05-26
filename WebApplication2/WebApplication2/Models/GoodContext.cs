using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class GoodContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Order> Orders { get; set; }
        public GoodContext(DbContextOptions<GoodContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
