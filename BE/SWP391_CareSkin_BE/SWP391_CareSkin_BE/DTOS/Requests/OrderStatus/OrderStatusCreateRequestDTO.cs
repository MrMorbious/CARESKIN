using System.ComponentModel.DataAnnotations;

namespace SWP391_CareSkin_BE.DTOS.Requests.OrderStatus
{
    public class OrderStatusCreateRequestDTO
    {
        [Required(ErrorMessage = "Order status name is required")]
        public string OrderStatusName { get; set; }
    }
}
