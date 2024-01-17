using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class PurchaseItem
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal? Actualprice { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
