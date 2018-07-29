using AutoMapper;
using ProductShop.DataProcessor.Models.Import;
using ProductShop.Models;

namespace ProductShop.App
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<User, UserImportDto>().ReverseMap();
        }
    }
}