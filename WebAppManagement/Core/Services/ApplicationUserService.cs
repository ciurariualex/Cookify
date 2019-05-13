using Core.Context;
using Core.Interfaces;
using Core.Models;
using Core.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ApplicationUserService : BaseEntityService<ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(SchedulerContext context) : base(context)
        {
        }
    }
}

