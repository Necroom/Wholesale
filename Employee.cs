using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wholesale_LINQ;

public partial class Employee
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string SurName { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Middlename { get; set; } = null!;
    [Required]
    public string? Position { get; set; }
    [Required]
    public int StorageId { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual Storage Storage { get; set; } = null!;
}
