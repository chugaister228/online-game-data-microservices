using Microsoft.EntityFrameworkCore;
using PlayerStats.Data.Models;
using System.Reflection;

namespace PlayerStats.DAL
{
    public class PlayerStatsContext : DbContext
    {
        public PlayerStatsContext(DbContextOptions<PlayerStatsContext> options) : base(options) { }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Violation> Violations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            PlayerStatsSeeding.SeedingInit();
            modelBuilder.Entity<Friend>().HasData(PlayerStatsSeeding.Friends);
            modelBuilder.Entity<Player>().HasData(PlayerStatsSeeding.Players);
            modelBuilder.Entity<Violation>().HasData(PlayerStatsSeeding.Violations);
        }
    }
}
