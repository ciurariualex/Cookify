using Core.Domain.Business.Models.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Models.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
    }
}
