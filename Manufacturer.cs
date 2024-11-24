using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wholesale_LINQ;

public partial class Manufacturer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
