using System;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? SellerId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Category { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Seller? Seller { get; set; }
}
