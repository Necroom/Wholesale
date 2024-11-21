using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Release
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? SendingDate { get; set; }

    public string ShippingMethod { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
