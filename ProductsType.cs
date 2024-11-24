using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wholesale_LINQ;

public partial class ProductsType
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public string? Features { get; set; }
    [Required]
    public string StorageConditions { get; set; } = null!;
    [Required]
    public string Packing { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
