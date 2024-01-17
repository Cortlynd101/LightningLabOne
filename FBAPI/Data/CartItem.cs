using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class CartItem
{
    public int Id { get; set; }

    public int? CartId { get; set; }

    public int? ItemId { get; set; }

    public decimal? ActualPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Item? Item { get; set; }
}
