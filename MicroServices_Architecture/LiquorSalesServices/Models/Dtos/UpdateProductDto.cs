namespace LiquorSalesService.Models.Dtos
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }      
        public decimal CostPrice { get; set; }        
        public string SellingPrice {get; set; }  
        public string ImageUrl { get; set; }         
        public int StockingQuantity { get; set; }         
        public DateTime ExpiryDate { get; set; }
    }
}