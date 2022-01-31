using CustomerHomework.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Data.Concrete.EntityFramework
{
    public class CustomerHomeworkDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = CustomerHomerwork; 
            //Trusted_Connection = True; Connect Timeout = 30; 
            //MultipleActiveResultSets = True; ");
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=BasicWebApi;User=sa;Password=Password123@jkl#;");

        }
    }
}
