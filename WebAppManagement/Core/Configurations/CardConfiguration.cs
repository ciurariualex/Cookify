namespace Core.Configurations
{
    using Core.Models;
    using Core.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal sealed class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");

            builder.HasQueryFilter(card => !card.IsDeleted);

            builder.HasKey(card => card.Id)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(mobileApplicationUser => mobileApplicationUser.CreatedAt)
                .IsRequired();

            builder.HasOne(card => card.MobileApplicationUser)
              .WithMany(mobileApplicationUser => mobileApplicationUser.Cards)
              .HasForeignKey(card => card.MobileApplicationUserId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(mobileApplicationUser => mobileApplicationUser.CreatedBy)
                .IsRequired();

            builder.Property(mobileApplicationUser => mobileApplicationUser.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}