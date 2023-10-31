using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerStats.Data.Models;

namespace PlayerStats.DAL.Configuration
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.
                HasKey(f => f.ID);

            builder
                .Property(f => f.ID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(f => f.Friendname)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(f => f.Player)
                .WithMany(p => p.Friends)
                .HasForeignKey(f => f.PlayerID);
        }
    }
}
