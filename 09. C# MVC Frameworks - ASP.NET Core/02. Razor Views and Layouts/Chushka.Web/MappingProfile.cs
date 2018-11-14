using AutoMapper;
using Chushka.Models;
using Chushka.Web.Models.Orders;
using Chushka.Web.Models.Products;

namespace Chushka.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, DetailsProductViewModel>()
                .ReverseMap();
            CreateMap<Product, CreateProductViewModel>()
                .ReverseMap();

            CreateMap<Order, DetailsOrderViewModel>()
                .ForMember(
                    dest => dest.Client,
                    opt => opt.MapFrom(src => src.Client.UserName)
                )
                .ForMember(
                    dest => dest.Product,
                    opt => opt.MapFrom(src => src.Product.Name)
                ).ReverseMap();
        }
    }
}