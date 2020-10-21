using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Data
{
    public class NkTechSolutionContext : IdentityDbContext<StoreUser>
    {
        public NkTechSolutionContext( DbContextOptions<NkTechSolutionContext>options): base(options)
        {
            }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate=DateTime.UtcNow,
                    OrderNumber="12345"
                });
            
        } 
    }
}
