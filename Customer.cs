using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wholesale_LINQ;

public partial class Customer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Addres { get; set; } = null!;
    [Required]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();
}
