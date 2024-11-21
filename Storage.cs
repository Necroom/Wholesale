using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Storage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
