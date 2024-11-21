using System;
using System.Collections.Generic;

namespace Wholesale_LINQ;

public partial class Employee
{
    public int Id { get; set; }

    public string SurName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Middlename { get; set; } = null!;

    public string? Position { get; set; }

    public int StorageId { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual Storage Storage { get; set; } = null!;
}
