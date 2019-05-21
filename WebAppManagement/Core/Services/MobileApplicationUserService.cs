using Core.Context;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MobileApplicationUserService : BaseService<MobileApplicationUser, Guid>, IMobileApplicationUserService
    {
        public MobileApplicationUserService(SchedulerContext context) : base(context)
        {
        }

        public async Task<List<MobileApplicationUser>> GetPagedAsync(IQueryable<MobileApplicationUser> query, int page, int size)
        {
            return await query
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<int> GetPagedCountAsync(IQueryable<MobileApplicationUser> pagedQuery)
        {
            return await pagedQuery.CountAsync();
        }

        public async Task<List<MobileApplicationUser>> GetEagerAllAsync()
        {
            return await context
               .MobileApplicationUsers
               .AsNoTracking()
               .Include(mobileApplicationUser => mobileApplicationUser.Cards)
               .ToListAsync();
        }
    }
}

