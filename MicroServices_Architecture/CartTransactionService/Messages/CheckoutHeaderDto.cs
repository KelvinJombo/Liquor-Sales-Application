using CartTransactionService.Models.Dtos;
using LiquorSale.MessageBus;

namespace CartTransactionService.Messages
{
    public class CheckoutHeaderDto : BaseMessage
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double OrderTotal { get; set; }
        public double DiscountTotal { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DeliveryTime { get; set;}
        public string PhoneNumber {get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public int CartTotalItems { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; } 
    }
}