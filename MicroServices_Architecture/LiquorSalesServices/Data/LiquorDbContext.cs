using LiquorSalesService.Models;
using Microsoft.EntityFrameworkCore;

namespace LiquorSalesSrvice.Data
{
    public class LiquorDbContext : DbContext
    {
        public LiquorDbContext(DbContextOptions<LiquorDbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
    }
}