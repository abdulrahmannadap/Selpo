using System;
using System.Collections.Generic;

namespace Selpo.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public string CompanyMobile { get; set; } = null!;
}
