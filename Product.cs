using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wholesale_LINQ;

public partial class Product
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int TypeId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int ManufacturerId { get; set; }
    [Required]
    public DateOnly ExpirationDate { get; set; }
    [Required]
    public int Price { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual ProductsType Type { get; set; } = null!;
}
