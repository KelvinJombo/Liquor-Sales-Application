using System.ComponentModel.DataAnnotations;

namespace CartTransactionService.Models.Dtos
{
    public class CartHeaderDto
    {
        [Key]
        public string CartHeaderId { get; set; }    
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}