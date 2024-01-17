using FoodBoxClassLibrary.Data;
using FrontEnd.Pages;
using FrontEnd.Pages.Dto;

namespace FrontEnd.Shared
{
    public class OrderState
    {
        public List<OrderingItemDto> ItemsInOrder { get; set; } = new List<OrderingItemDto>();
        public Restaurant? Restaurant { get; set; } = null;
        public int itemCounter { get; set; }
        public int previousItemCount { get; set; }

        // public bool HasBeenOrdered { get; set; } = false;
        // public bool HasBeenPaidFor { get; set; } = false;
    }
}
