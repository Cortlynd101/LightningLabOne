using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class Item
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public string? Ingredients { get; set; }

    public decimal? SuggestedPrice { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<FavoriteItem> FavoriteItems { get; set; } = new List<FavoriteItem>();

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual ICollection<RestaurantItem> RestaurantItems { get; set; } = new List<RestaurantItem>();
}
