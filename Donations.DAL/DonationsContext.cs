using Donations.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL
{
    public class DonationsContext : DbContext
    {
        public DonationsContext(DbContextOptions<DonationsContext> options) : base(options) { }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            DonationsSeeding.SeedingInit();
            modelBuilder.Entity<Donation>().HasData(DonationsSeeding.Donations);
            modelBuilder.Entity<Product>().HasData(DonationsSeeding.Products);
            modelBuilder.Entity<User>().HasData(DonationsSeeding.Users);
        }
    }
}
