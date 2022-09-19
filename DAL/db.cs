using System;
using System.Collections.Generic;
using System.Text;
using be;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class db : IdentityDbContext<UserApp>
    {
        public db() : base()
        {
        }
        public db(DbContextOptions<db> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO Move connection string to a secure location
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K43MI5S; Initial Catalog=oxinWa; Integrated Security=True");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<product> products { get; set; }
        public DbSet<type> types { get; set; }
        public DbSet<type> gallery { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_product> Order_products { get; set; }
        public DbSet<orderId> orderIds { get; set; }

    }
}
