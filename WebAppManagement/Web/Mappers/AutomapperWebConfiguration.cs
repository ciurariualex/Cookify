using AutoMapper;
using Core.Models;
using Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Authentication.Models;

namespace Web.Mappers
{
    public class AutomapperWebConfiguration
    {
        public class MappingEntity : Profile
        {
            public MappingEntity()
            {
                CreateMap<UserRegisterViewModel, ApplicationUser>()
                    .ReverseMap();
            }
        }
    }
}
