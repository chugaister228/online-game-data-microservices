using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skins.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.DAL.Configuration
{
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.
                HasKey(w => w.ID);

            builder
                .Property(w => w.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(w => w.Rarity)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(w => w.TypeOfWeapon)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
