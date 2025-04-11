using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_CareSkin_BE.Models
{
    [Table("Promotion")]
    public class Promotion
    {
        public int PromotionId { get; set; }

        public string PromotionName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }

        public DateOnly Start_Date { get; set; }

        public DateOnly End_Date { get; set; }

        public bool IsActive { get; set; }
        
        // Add promotion type to distinguish between product and order promotions
        public PromotionType PromotionType { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<PromotionProduct>? PromotionProducts { get; set; } = new List<PromotionProduct>();
        public virtual ICollection<PromotionCustomer>? PromotionCustomers { get; set; } = new List<PromotionCustomer>();
    }
    
    public enum PromotionType
    {
        Product = 1,
        Order = 2
    }
}
