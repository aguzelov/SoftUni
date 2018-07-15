using AutoMapper;
using ProductShop.App.Models;
using ProductShop.Models;

namespace ProductShop.App
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductWithSellerNamesDto, Product>();
            CreateMap<SoldProductDto, Product>();
            CreateMap<UserDto, User>();
            CreateMap<CategoryByProductsDto, Category>();
            CreateMap<UserAndProductDto, User>();
            CreateMap<ProductNameAndPriceDto, Product>();
            CreateMap<ProductWithBuyerNamesDto, Product>();
        }
    }
}