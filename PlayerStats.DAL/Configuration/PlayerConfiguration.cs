using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.DAL.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.
                HasKey(p => p.ID);

            builder
                .Property(p => p.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(p => p.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Wins);

            builder
                .Property(p => p.TotalGamesPlayed);

            builder
                .Property(p => p.Rating);
        }
    }
}
