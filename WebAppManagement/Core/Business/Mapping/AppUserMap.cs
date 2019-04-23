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

            builder.Property(appUser => appUser.UserName)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(appUser => appUser.Token)
                .HasMaxLength(4001)
                .IsRequired();

            builder.Property(appUser => appUser.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(appUser => appUser.Address)
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
