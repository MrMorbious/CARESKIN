using SWP391_CareSkin_BE.DTOS.RatingFeedback;
using SWP391_CareSkin_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWP391_CareSkin_BE.Mappers
{
    public static class RatingFeedbackMapper
    {
        public static RatingFeedbackDTO ToDTO(RatingFeedback ratingFeedback)
        {
            if (ratingFeedback == null)
                return null;
                
            return new RatingFeedbackDTO
            {
                RatingFeedbackId = ratingFeedback.RatingFeedbackId,
                CustomerId = ratingFeedback.CustomerId,
                CustomerName = ratingFeedback.Customer?.FullName,
                CustomerAvatar = ratingFeedback.Customer?.PictureUrl,
                ProductId = ratingFeedback.ProductId,
                ProductName = ratingFeedback.Product?.ProductName,
                Rating = ratingFeedback.Rating,
                FeedBack = ratingFeedback.FeedBack,
                CreatedDate = ratingFeedback.CreatedDate,
                UpdatedDate = ratingFeedback.UpdatedDate,
                IsActive = ratingFeedback.IsActive,
                FeedbackImages = ratingFeedback.RatingFeedbackImages?.Select(i => ToDTO(i)).ToList()
            };
        }
        
        public static RatingFeedbackImageDTO ToDTO(RatingFeedbackImage image)
        {
            if (image == null)
                return null;
                
            return new RatingFeedbackImageDTO
            {
                RatingFeedbackImageId = image.RatingFeedbackImageId,
                RatingFeedbackId = image.RatingFeedbackId,
                FeedbackImageUrl = image.FeedbackImageUrl
            };
        }
        
        public static List<RatingFeedbackDTO> ToDTOList(IEnumerable<RatingFeedback> ratingFeedbacks)
        {
            return ratingFeedbacks?.Select(ToDTO).ToList() ?? new List<RatingFeedbackDTO>();
        }

        public static RatingFeedback ToEntity(int customerId, CreateRatingFeedbackDTO createDto)
        {
            if (createDto == null)
                return null;

            return new RatingFeedback
            {
                CustomerId = customerId,
                ProductId = createDto.ProductId,
                Rating = createDto.Rating,
                FeedBack = createDto.FeedBack,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true 
            };
        }

        public static void UpdateEntity(RatingFeedback ratingFeedback, UpdateRatingFeedbackDTO updateDto)
        {
            if (ratingFeedback == null || updateDto == null)
                return;

            ratingFeedback.Rating = updateDto.Rating;
            ratingFeedback.FeedBack = updateDto.FeedBack;
            ratingFeedback.UpdatedDate = DateTime.UtcNow;
        }
    }
}
