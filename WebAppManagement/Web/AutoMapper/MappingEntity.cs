using AutoMapper;
using Core.Models.User;
using Web.ViewModels.User;


namespace Web.AutoMapper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ReverseMap();
        }
    }
}
