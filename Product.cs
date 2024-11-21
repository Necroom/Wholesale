using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string? Name { get; set; }

    public int ManufacturerId { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public int Price { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual ProductsType Type { get; set; } = null!;
}
