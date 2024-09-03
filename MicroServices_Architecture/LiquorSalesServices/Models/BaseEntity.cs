using System.ComponentModel.DataAnnotations;

namespace LiquorSalesService.Model
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedStockAt { get; set; } = DateTime.Now;
        public DateTime ModifiedStockAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}