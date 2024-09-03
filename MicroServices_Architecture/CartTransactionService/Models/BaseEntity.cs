using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartTransactionService.Models
{
    public class BaseEntity
    {    
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedStockAt { get; set; } = DateTime.Now;
        public DateTime ModifiedStockAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
 
}