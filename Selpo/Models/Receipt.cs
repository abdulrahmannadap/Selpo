using System;
using System.Collections.Generic;

namespace Selpo.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }

    public int? SenderId { get; set; }

    public string Bank { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string RecipientName { get; set; } = null!;

    public string Ifsc { get; set; } = null!;

    public string? Remark { get; set; }

    public virtual Sender? Sender { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
