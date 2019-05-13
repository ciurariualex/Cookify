namespace Core.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    internal sealed class DesignTimeContextFactory : IDesignTimeDbContextFactory<SchedulerContext>
    {
        SchedulerContext IDesignTimeDbContextFactory<SchedulerContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchedulerContext>();
            optionsBuilder.UseSqlServer("Server = tcp:web20190422015321dbserver.database.windows.net, 1433; Initial Catalog = CookifyDb; Persist Security Info = False; User ID = adminMM; Password = Parola123!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ");
            return new SchedulerContext(optionsBuilder.Options);
        }
    }
}