using System;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? WorkingHours { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
