using Core.Business.Mapping;
using Core.Models;
using Core.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Business.Models
{
    public class BaseModel : IdentityDbContext<User>
    {
        public BaseModel(DbContextOptions<BaseModel> options)
            : base(options)
        { }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserMap());
        }
    }
}
