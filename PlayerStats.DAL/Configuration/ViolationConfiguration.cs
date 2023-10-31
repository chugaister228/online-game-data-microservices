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
    public class ViolationConfiguration : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.
                HasKey(v => v.ID);

            builder
                .Property(v => v.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(v => v.Type)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(v => v.Description)
                .HasMaxLength(1000);

            builder
                .HasOne(v => v.Player)
                .WithMany(p => p.Violations)
                .HasForeignKey(v => v.PlayerID);
        }
    }
}
