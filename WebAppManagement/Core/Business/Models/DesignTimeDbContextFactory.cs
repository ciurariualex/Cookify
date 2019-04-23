using Core.Domain.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Models
{
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseModel>
    {
        BaseModel IDesignTimeDbContextFactory<BaseModel>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseModel>();
            optionsBuilder.UseSqlServer("Server=tcp:web20190422015321dbserver.database.windows.net,1433;Initial Catalog=Web20190422015321_db_mm;Persist Security Info=False;User ID=adminMM;Password=Parola123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new BaseModel(optionsBuilder.Options);
        }
    }
}
