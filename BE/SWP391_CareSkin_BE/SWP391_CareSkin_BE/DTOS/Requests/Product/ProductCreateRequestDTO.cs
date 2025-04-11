using SWP391_CareSkin_BE.DTOs.Requests.Product;
using SWP391_CareSkin_BE.DTOS.Responses;
using SWP391_CareSkin_BE.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SWP391_CareSkin_BE.DTOS.Requests
{
    public class ProductCreateRequestDTO
    {
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        // File ảnh chính gửi từ client
        public IFormFile PictureFile { get; set; }
        
        // Danh sách các ảnh phụ gửi từ client
        public List<IFormFile> AdditionalPictures { get; set; }

        public List<ProductForSkinTypeCreateRequestDTO> ProductForSkinTypes { get; set; }

        // Dữ liệu cho variation khi tạo sản phẩm
        public List<ProductVariationCreateRequestDTO> Variations { get; set; }

        public List<ProductMainIngredientCreateRequestDTO> MainIngredients { get; set; }

        public List<ProductDetailIngredientCreateRequestDTO> DetailIngredients { get; set; }

        public List<ProductUsageCreateRequestDTO> Usages { get; set; }
    }
}
