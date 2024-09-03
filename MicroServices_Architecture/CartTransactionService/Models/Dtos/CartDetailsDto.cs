using CartTransactionService.Models;

namespace CartTransactionService.Models.Dtos
{
    public class CartDetailsDto
    {
        public string CartDetailsId { get; set;}  
        public string CartHeaderId { get; set;}         
        public virtual CartHeader CartHeader { get; set;}
        public string ProductsId { get; set;}        
        public virtual Products Products { get; set;}
        public decimal TotalAmount { get; set; }  
        public int Count { get; set;} 
    }
}