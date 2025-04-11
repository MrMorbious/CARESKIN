﻿namespace SWP391_CareSkin_BE.DTOs.Responses
{
    public class OrderProductDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ProductVariationId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
    }
}
