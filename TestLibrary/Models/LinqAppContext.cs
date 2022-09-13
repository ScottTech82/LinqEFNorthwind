using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Models
{
    public class LinqAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!; 
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public LinqAppContext() { }  //need default if not doing web app.
        public LinqAppContext(DbContextOptions options) : base(options) { }

        //only need if doing a non-web app.  If doing web app you do not need this.
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connStr = @"server=localhost\sqlexpress01;database=Northwind;trusted_connection=true;";
            if(!builder.IsConfigured) //if builder is not configured yet, connect
            {
                builder.UseSqlServer(connStr);
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //when a table has a space and 2 foreign Keys
            builder.Entity<OrderDetail>(e =>
            {
                e.ToTable("Order Details");
                e.HasKey(x => new { x.OrderId, x.ProductId });
            });
        }
 


        
    }
}
