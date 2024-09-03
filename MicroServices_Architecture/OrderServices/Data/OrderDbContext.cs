using Microsoft.EntityFrameworkCore;
using OrderServices.Models;

namespace OrderServices.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails {get; set; }
    } 
}