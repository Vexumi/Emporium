using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Models.Dto;
using Emporium.Services;
using System.Collections.Generic;

namespace Emporium.ViewModels.DialogWindows
{
    public class OrderDetailsViewModel : BaseDetailsViewModel<Order, OrdersService>
    {
        public OrderDetailsViewModel(OrdersService ordersService) : base(ordersService)
        {

        }

        public IEnumerable<OrderDetailDto> OrderDetails
        {
            get { return this.service.GetOrderDetails(Item); }
        }
    }
}
