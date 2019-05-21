namespace Core.Interfaces
{
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMobileApplicationUserService : IBaseService<MobileApplicationUser, Guid>
    {
        Task<List<MobileApplicationUser>> GetPagedAsync(IQueryable<MobileApplicationUser> query, int page, int size);
        Task<int> GetPagedCountAsync(IQueryable<MobileApplicationUser> pagedQuery);
        Task<List<MobileApplicationUser>> GetEagerAllAsync();
    }
}
