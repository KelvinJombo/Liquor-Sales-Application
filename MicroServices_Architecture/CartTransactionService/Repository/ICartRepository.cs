using CartTransactionService.Models.Dtos;
using System.Threading.Tasks;

namespace CartTransactionService.Repository
{
    public interface ICartRepository 
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(string cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}