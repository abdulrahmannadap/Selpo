using System;
using System.Collections.Generic;

namespace Selpo.Models;

public partial class InvoicePrint
{
    public int InvoiceId { get; set; }

    public DateTime TransactionDateTime { get; set; }

    public string SenderName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string RecipientName { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string Ifsc { get; set; } = null!;

    public string? Remark { get; set; }

    public decimal Amount { get; set; }

    public decimal Charges { get; set; }

    public decimal AmountWithCharges { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public string CompanyMobile { get; set; } = null!;

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
