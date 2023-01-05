using Basic_Banking_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.DAL.Database
{
    public class DbContainer : DbContext
    {
        public DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = . ; database = Bank ; integrated security = true");
        }
    }
}
