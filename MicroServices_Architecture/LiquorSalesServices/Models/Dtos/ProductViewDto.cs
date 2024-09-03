namespace LiquorSalesService.Models.Dtos
{
    public class ProductViewDto
    {
        public string Id { get; set;}
        public string ProductName { get; set; }  
        public string CompanyName { get; set; }  
        public string Description { get; set; }          
        public string SellingPrice {get; set; }  
        public string ImageUrl { get; set; }         
        public int TotalStock { get; set; } 
        public DateTime ProductionDate { get; set;}        
        public DateTime ExpiryDate { get; set; }
    }
}