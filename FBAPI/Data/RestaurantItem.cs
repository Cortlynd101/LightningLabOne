using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class RestaurantItem
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int RestaurantId { get; set; }

    public decimal Price { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Restaurant Restaurant { get; set; } = null!;
}
