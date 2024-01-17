using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class Coupon
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    /// <summary>
    /// Dollars off, not percent
    /// </summary>
    public decimal Discount { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
