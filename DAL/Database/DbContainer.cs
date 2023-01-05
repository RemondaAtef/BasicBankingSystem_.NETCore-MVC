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
        public DbSet<History> History { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = . ; database = Bank ; integrated security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasData(new Customers { Account_Num = "1258-6943-5764-12384", Name = "Tom", Email = "Tom@gmail.com", Current_Balance = "1234$" },
                new Customers { Account_Num = "4867-2134-6458-4796", Name = "Jena", Email = "Jena@gmail.com", Current_Balance = "4590$"},
                new Customers { Account_Num = "9745-1463-4795-1423", Name = "Seray", Email = "Seray@gmail.com", Current_Balance = "487$" },
                new Customers {  Account_Num = "7436-1965-4567-2497", Name = "Jerry", Email = "Jerry@gmail.com", Current_Balance = "500$"},
                new Customers { Account_Num = "7894-5369-4126-7894", Name = "Dina", Email = "Dina@gmail.com" , Current_Balance = "15$"},
                new Customers { Account_Num ="4897-1235-4795-6879", Name = "Novier", Email = "Novier@gmail.com", Current_Balance = "800$" },
                new Customers { Account_Num = "7842-3694-1287-9465", Name = "Nevya", Email = "Nevya@gmail.com", Current_Balance = "9870$"},
                new Customers { Account_Num = "9473-1658-4239-7458", Name = "Nehal", Email = "Nehal@gmail.com", Current_Balance = "8700$" },
                new Customers { Account_Num = "2436-8756-4123-4891", Name = "Mona", Email = "Mona@gmail.com", Current_Balance = "6743200$" },
                new Customers { Account_Num = "1297-5304-7890-1435", Name = "Sally", Email = "Sally@gmail.com", Current_Balance = "970$" },
                new Customers { Account_Num = "8402-9413-78912-1436", Name = "Yasin", Email = "Yasin@gmail.com", Current_Balance = "5460$" },
                new Customers { Account_Num = "2049-4503-7942-8576", Name = "Ruchir", Email = "Ruchir@gmail.com", Current_Balance = "600$" },
                new Customers { Account_Num = "8730-4591-2576-3971", Name = "Preetha", Email = "Preetha@gmail.com", Current_Balance = "75600$" },
                new Customers { Account_Num = "4975-2364-7941-0367", Name = "Roy", Email = "Roy@gmail.com", Current_Balance = "400$" });
        }
    }
}
