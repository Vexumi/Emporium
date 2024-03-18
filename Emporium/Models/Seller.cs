using Emporium.Infrastructure.Based;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class Seller : BaseEntity
{
    public string? Address { get; set; }

    public long? Itin { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User User { get; set; } = null!;
}
