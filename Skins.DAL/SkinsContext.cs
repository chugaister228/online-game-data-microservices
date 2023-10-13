using Microsoft.EntityFrameworkCore;
using Skins.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skins.DAL
{
    public class SkinsContext : DbContext
    {
        public SkinsContext(DbContextOptions<SkinsContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SkinsSeeding.SeedingInit();
            modelBuilder.Entity<Character>().HasData(SkinsSeeding.Characters);
            modelBuilder.Entity<Pet>().HasData(SkinsSeeding.Pets);
            modelBuilder.Entity<Weapon>().HasData(SkinsSeeding.Weapons);
        }
    }
}
