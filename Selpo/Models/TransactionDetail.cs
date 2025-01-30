using System;
using System.Collections.Generic;

namespace Selpo.Models;

public partial class TransactionDetail
{
    public int TransactionId { get; set; }

    public int? ReceiptId { get; set; }

    public int? InvoiceId { get; set; }

    public DateTime TransactionDateTime { get; set; }

    public decimal Amount { get; set; }

    public decimal Charges { get; set; }

    public decimal AmountWithCharges { get; set; }

    public virtual InvoicePrint? Invoice { get; set; }

    public virtual Receipt? Receipt { get; set; }
}
