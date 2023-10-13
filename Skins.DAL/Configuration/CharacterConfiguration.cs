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
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.
                HasKey(c => c.ID);

            builder
                .Property(c => c.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.Rarity)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(c => c.RaceOfCharacter)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(c => c.Pet)
                .WithOne(p => p.Character)
                .HasForeignKey<Pet>(p => p.CharacterID);

            builder
                .HasOne(c => c.Weapon)
                .WithOne(w => w.Character)
                .HasForeignKey<Weapon>(w => w.CharacterID);
        }
    }
}
