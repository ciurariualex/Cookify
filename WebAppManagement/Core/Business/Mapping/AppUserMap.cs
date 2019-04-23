using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Business.Mapping
{
    internal sealed class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasQueryFilter(appUser => !appUser.IsDeleted);

            builder.HasKey(appUser => appUser.Id)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(appUser => appUser.LastName)
               .HasMaxLength(50);

            builder.Property(appUser => appUser.FirstName)
                .HasMaxLength(50);

            builder.Property(appUser => appUser.RestaurantName)
                .HasMaxLength(50);

            builder.Property(appUser => appUser.AuthToken)
                .HasMaxLength(4001)
                .IsRequired();

            builder.Property(appUser => appUser.Created)
                .IsRequired();

            builder.Property(appUser => appUser.Edited)
                .IsRequired();

            builder.Property(appUser => appUser.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
