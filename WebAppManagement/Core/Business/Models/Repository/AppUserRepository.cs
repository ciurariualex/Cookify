using Core.Business.Models.Interfaces;
using Core.Domain.Business.Models;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Models.Repository
{
    public class AppUserRepository : StableRepository<AppUser>, IAppUserRepository
    {
        protected readonly BaseModel _dbcontext;

        public AppUserRepository(BaseModel dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }
    }
}
