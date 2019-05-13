namespace Core.Configurations
{
    using Core.Models;
    using Core.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal sealed class MobileApplicationUserConfiguration : IEntityTypeConfiguration<MobileApplicationUser>
    {
        public void Configure(EntityTypeBuilder<MobileApplicationUser> builder)
        {
            builder.ToTable("MobileApplicationUsers");

            builder.HasQueryFilter(mobileApplicationUser => !mobileApplicationUser.IsDeleted);

            builder.HasKey(mobileApplicationUser => mobileApplicationUser.Id)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(mobileApplicationUser => mobileApplicationUser.AuthToken)
                .IsRequired();

            builder.Property(mobileApplicationUser => mobileApplicationUser.Longitude)
                .IsRequired(false);

            builder.Property(mobileApplicationUser => mobileApplicationUser.Latitude)
                .IsRequired(false);

            builder.Property(mobileApplicationUser => mobileApplicationUser.UserType)
                .HasDefaultValue(UserType.User)
                .IsRequired();

            builder.Property(mobileApplicationUser => mobileApplicationUser.CreatedAt)
                .IsRequired();

            builder.Property(mobileApplicationUser => mobileApplicationUser.CreatedBy)
                .IsRequired();

            builder.Property(mobileApplicationUser => mobileApplicationUser.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}