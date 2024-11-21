using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Receipt
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateOnly ReceiptDate { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? SendingDate { get; set; }

    public string Value { get; set; } = null!;

    public int Price { get; set; }

    public int SupplierId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
