using CartTransactionService.Models;

namespace CartTransactionService.Models.Dtos
{
    public class CartDto
    { 
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}