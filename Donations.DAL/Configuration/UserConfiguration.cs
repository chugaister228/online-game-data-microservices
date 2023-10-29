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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.
                HasKey(u => u.ID);

            builder
                .Property(u => u.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(u => u.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.CreditCardNumber)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
