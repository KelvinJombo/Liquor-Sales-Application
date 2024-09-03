using Microsoft.EntityFrameworkCore;
using OrderServices.Data;
using OrderServices.Models;

namespace OrderServices.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DbContextOptions<OrderDbContext> _dbContext;

            public OrderRepository(DbContextOptions<OrderDbContext> dbContext)
            {
                _dbContext = dbContext;
            }


        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            try
            {

             await using var _db = new OrderDbContext(_dbContext);
             _db.OrderHeaders.Add(orderHeader);
             await _db.SaveChangesAsync();
             return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task UpdateOrderPaymentStatus(int OrderHeaderId, bool paid)
        {
             await using var _db = new OrderDbContext(_dbContext);
             var orderHeaderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(x => x.OrderHeaderId == OrderHeaderId);
             if (orderHeaderFromDb != null)
             {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();
             }
        }
    }
}