using System.ComponentModel.DataAnnotations;
using LiquorSalesService.Model;

namespace LiquorSalesService.Models
{public class Products : BaseEntity
    {        
        [Required]
        public string ProductName { get; set; }  
        public string CompanyName { get; set; }  
        public string Description { get; set; }  
        [Required]
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
    