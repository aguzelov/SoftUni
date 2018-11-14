using AutoMapper;
using Panda.App.Models;
using Panda.Models;

namespace Panda.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            CreateMap<Package, PackageDetailsViewModel>()
                .ForMember(
                dest => dest.Recipient,
                opt => opt.MapFrom(src => src.Recipient.UserName)
                )
                .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.ShippingAddress)
                ).ReverseMap();
            CreateMap<Package, PackageGreateViewModel>().ReverseMap();
            CreateMap<Package, PackageViewModel>().ReverseMap();

            CreateMap<Receipt, ReceiptIndexDetailViewModel>()
                .ForMember(
                dest => dest.Recipient,
                opt => opt.MapFrom(src => src.Recipient.UserName)
                ).ReverseMap();

            CreateMap<Receipt, ReceiptsDetailsViewModel>()
                .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Package.ShippingAddress)
                )
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Package.Description)
                )
                .ForMember(
                dest => dest.Recipient,
                opt => opt.MapFrom(src => src.Recipient.UserName)
                )
                .ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.Package.Weight)
                )
                .ForMember(
                dest => dest.Total,
                opt => opt.MapFrom(src => src.Fee)
                ).ReverseMap();
        }
    }
}
