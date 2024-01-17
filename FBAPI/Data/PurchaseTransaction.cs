using System;
using System.Collections.Generic;

namespace FBAPI.Data;

public partial class PurchaseTransaction
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public decimal AmountPaid { get; set; }

    public virtual Purchase Purchase { get; set; } = null!;
}
