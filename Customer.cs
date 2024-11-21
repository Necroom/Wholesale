using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Addres { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();
}
