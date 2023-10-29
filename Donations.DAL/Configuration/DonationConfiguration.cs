using Donations.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Configuration
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.
                HasKey(d => d.ID);

            builder
                .Property(d => d.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(d => d.Sum)
                .HasMaxLength(100)
                .IsRequired();
                
            builder
                .Property(d => d.Date)
                .IsRequired();

            builder
                .HasOne(d => d.Product)
                .WithMany(p => p.Donations)
                .HasForeignKey(d => d.ProductID);

            builder
                .HasOne(d => d.User)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.UserID);
        }
    }
}
