using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServices.Models
{
    public class OrderDetails
    {
        [Key]
        public string OrderDetailsId { get; set; }
        public string OrderHeaderId { get; set; }
        //[ForeignKey(OrderHeaderId)]
        public virtual OrderHeader OrderHeader { get; set;}
        public string ProductsId { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    } 
}