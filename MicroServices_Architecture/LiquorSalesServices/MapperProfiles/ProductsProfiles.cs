using AutoMapper;
using LiquorSalesService.Models;
using LiquorSalesService.Models.Dtos;

namespace LiquorSalesServices.MapperProfiles
{
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            CreateMap<Products, ProductViewDto>();
            CreateMap<CreateProductDto, Products>();
        }
    }
}