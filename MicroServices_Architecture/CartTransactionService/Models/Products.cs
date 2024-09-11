using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartTransactionService.Models
{
    public class Products : BaseEntity
    {        
        [Required]
        public string ProductsId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ProductName { get; set; }  
        public string CompanyName { get; set; }  
        public string Description { get; set; }  
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPrice { get; set; }
        [Required]
        public string SellingPrice {get; set; }  
        public string ImageUrl { get; set; } 
        [Required]
        public int StockingQuantity { get; set; }    
        public int TotalStock { get; set; } 
        public DateTime ProductionDate { get; set;}
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
