using System;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string? Address { get; set; }

    public long? Itin { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User User { get; set; } = null!;
}
