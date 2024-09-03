using CartTransactionService.Models;
using Microsoft.EntityFrameworkCore;

namespace CartTransactionService.Data
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)  
        {            
        }

        public DbSet<Products> Products { get; set;}
        public DbSet<CartHeader> CartHeaders { get; set;}   
        public DbSet<CartDetails> CartDetails { get; set;}
    }
}

    
    
