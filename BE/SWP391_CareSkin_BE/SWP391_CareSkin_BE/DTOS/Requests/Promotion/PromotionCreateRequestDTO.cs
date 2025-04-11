using System;
using SWP391_CareSkin_BE.Models;

namespace SWP391_CareSkin_BE.DTOS.Requests.Promotion
{
    public class PromotionCreateRequestDTO
    {
        public string PromotionName { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public PromotionType PromotionType { get; set; }
    }
}
