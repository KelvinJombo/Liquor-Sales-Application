using AutoMapper;
using CartTransactionService.Models;
using CartTransactionService.Models.Dtos;

namespace CartTransactionService.MapperProfiles
{
    public class MappingConfig //: Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto,Products>().ReverseMap();
                config.CreateMap<CartHeader,CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                config.CreateMap<Cart, CartDto>().ReverseMap();
            });
            
            return mappingConfig;
        }
    }

    // public class CartProfiles : Profile
    // {
    //     public CartProfiles()
    //     {
    //          CreateMap<ProductDto,Products>().ReverseMap();
    //          CreateMap<CartHeader,CartHeaderDto>().ReverseMap();
    //          CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
    //          CreateMap<Cart, CartDto>().ReverseMap();
    //     }
    // }





}