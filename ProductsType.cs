using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class ProductsType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Features { get; set; }

    public string StorageConditions { get; set; } = null!;

    public string Packing { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
