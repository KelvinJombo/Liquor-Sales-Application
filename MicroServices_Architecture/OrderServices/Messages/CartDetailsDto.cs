using OrderServices.Messages;

namespace OrderServives.Messages
{
    public class CartDetailsDto
    {
        public string CartDetailsId { get; set;}
        public string CartHeaderId { get; set;}
        public string ProductsId { get; set;}
        public virtual ProductsDto ProductsDto{ get; set;}
        public int Count { get; set;}
    }
}