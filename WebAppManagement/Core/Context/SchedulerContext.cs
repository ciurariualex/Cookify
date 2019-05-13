namespace Core.Context
{
    using Core.Configurations;
    using Core.Models;
    using Core.Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public sealed class SchedulerContext : IdentityDbContext<ApplicationUser>
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {
        }

        public DbSet<MobileApplicationUser> MobileApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MobileApplicationUserConfiguration());

        }
    }
}