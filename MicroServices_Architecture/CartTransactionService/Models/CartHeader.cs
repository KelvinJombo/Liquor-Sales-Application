namespace CartTransactionService.Models
{
    public class CartHeader
    {
        public string CartHeaderId { get; set;} = Guid.NewGuid().ToString();
        public string UserId { get; set;} = string.Empty;
        public string CouponCode { get; set;}
    }
}