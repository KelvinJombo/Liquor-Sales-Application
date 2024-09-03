using LiquorSalesService.Models;
using LiquorSalesSrvice.Data;

namespace LiquorSalesService.Data
{
    public class ProductRepository : IProductsRepository
    {
        private readonly LiquorDbContext _context;

        public ProductRepository(LiquorDbContext context)
        {
            _context = context;
        }



        public void AddProduct(Products createProduct)
        {
             if (createProduct == null)
             {
                throw new ArgumentNullException(nameof(createProduct));
             }

             _context.Products.Add(createProduct);
        }

        // public Products GetProductsByExpiryDateRange(DateTime startDate, DateTime endDate)
        // {
        //      return _context.Products.Where(startDate, endDate).OrderByDescending();
        // }

        public Products GetProductsById(string id)
        {
             return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Products GetProductsByName(string productName)
        {
            return _context.Products.FirstOrDefault(p => p.ProductName == productName);
        }

        public IEnumerable<Products> GetAllProducts()
        {
             return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges() >= 0);
        }
    }
}