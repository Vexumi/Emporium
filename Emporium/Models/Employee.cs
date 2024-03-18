using Emporium.Infrastructure.Based;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class Employee : BaseEntity
{
    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public int? PickupPointId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual PickupPoint? PickupPoint { get; set; }

    public virtual User User { get; set; } = null!;
}
