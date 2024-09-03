using OrderServices.Models;

namespace OrderServices.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int OrderHeaderId, bool paid);
        
    }
}