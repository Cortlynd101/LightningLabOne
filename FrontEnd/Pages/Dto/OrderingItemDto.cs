using FoodBoxClassLibrary.Data;

namespace FrontEnd.Pages.Dto
{
    public class OrderingItemDto
    {
        public RestaurantItem RestrauntItem { get; set; }
        public int Quantity { get; set; }
        public decimal PriceXQty { get; set; }
    }
}
