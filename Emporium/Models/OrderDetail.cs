﻿using System;
using System.Collections.Generic;

namespace Emporium.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? PickupPointId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual PickupPoint? PickupPoint { get; set; }

    public virtual Product? Product { get; set; }
}