using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartTransactionService.Models
{
    public class CartDetails
    {
        public string CartDetailsId { get; set;} = Guid.NewGuid().ToString();
        [ForeignKey(nameof(CartHeaderId))]
        public string CartHeaderId { get; set;}        
        public virtual CartHeader CartHeader { get; set;}
        [ForeignKey(nameof(ProductsId))]
        public string ProductsId { get; set;}        
        public virtual Products Products { get; set;}
        public decimal TotalAmount { get; set; }  
        public int Count { get; set;} 
    }
}