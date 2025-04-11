using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_CareSkin_BE.Models
{
    [Table("PromotionProduct")]
    public class PromotionProduct
    {
        [Key]
        public int PromotionProductId { get; set; }
        public int ProductId { get; set; }
        public int PromotionId { get; set; }
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
