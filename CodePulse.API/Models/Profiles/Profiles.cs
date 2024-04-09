using AutoMapper;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;

namespace CodePulse.API.Models.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            //CreateMap<TraceSourceFactoryExtensions,TDestination>()
            CreateMap<CreateCategoryRequestDto, Category>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            
        }
    }
}
