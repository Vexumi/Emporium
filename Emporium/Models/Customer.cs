using Emporium.Infrastructure.Based;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class Customer : BaseEntity
{
    public string? CardNumber { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
