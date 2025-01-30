using System;
using System.Collections.Generic;

namespace Selpo.Models;

public partial class Sender
{
    public int SenderId { get; set; }

    public string Mobile { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
