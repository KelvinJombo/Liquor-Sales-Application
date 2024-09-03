using LiquorSalesService.Models;
using LiquorSalesService.Models.Dtos;

namespace LiquorSalesService.Data
{
    public interface IProductsRepository
    {
        bool SaveChanges();
        
        void AddProduct(Products createProduct);   
        Products GetProductsById(string id);
        IEnumerable<Products> GetAllProducts();
        Products GetProductsByName(string productName);
        //IEnumerable<ProductViewDto> GetProductsByExpiryDateRange(DateTime startDate, DateTime endDate);

    }
}