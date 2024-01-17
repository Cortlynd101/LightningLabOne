using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class Restaurant
{
    public int Id { get; set; }

    public string RestaurantName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? State { get; set; }

    public string? City { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<RestaurantItem> RestaurantItems { get; set; } = new List<RestaurantItem>();
}
