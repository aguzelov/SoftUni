using AutoMapper;
using FDMC.App.Models;
using FDMC.Models;

namespace FDMC.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Cat, CatDetailsViewModel>().ReverseMap();
            CreateMap<Cat, CatViewModel>().ReverseMap();
            CreateMap<Cat, AddCatViewModel>().ReverseMap();
        }
    }
}