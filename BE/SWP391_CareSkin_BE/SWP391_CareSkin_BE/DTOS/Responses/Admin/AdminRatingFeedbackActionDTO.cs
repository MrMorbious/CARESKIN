using System.ComponentModel.DataAnnotations;

namespace SWP391_CareSkin_BE.DTOS.RatingFeedback
{
    public class AdminRatingFeedbackActionDTO
    {
        [Required]
        public bool IsActive { get; set; }
        
        public string AdminComment { get; set; }
    }
}
