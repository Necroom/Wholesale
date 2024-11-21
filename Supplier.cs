using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Addres { get; set; } = null!;

    public string? Features { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
