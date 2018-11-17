using AutoMapper;

namespace Eventures.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Order, DetailsOrderViewModel>()
            //    .ForMember(
            //        dest => dest.Client,
            //        opt => opt.MapFrom(src => src.Client.UserName)
            //    )
            //    .ForMember(
            //        dest => dest.Product,
            //        opt => opt.MapFrom(src => src.Product.Name)
            //    ).ReverseMap();
        }
    }
}