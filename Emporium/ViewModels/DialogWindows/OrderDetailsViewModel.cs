using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using System.Linq;

namespace Emporium.ViewModels.DialogWindows
{
    public class OrderDetailsViewModel : BaseDetailsViewModel<Order, OrdersService>
    {
        public OrderDetailsViewModel(OrdersService ordersService) : base(ordersService)
        { }

        public OrderDetail[] OrderDetails
        {
            get { return Item.OrderDetails.ToArray(); }
            set
            {
                Item.OrderDetails = value;
                OnPropertyChanged("OrderDetails");
            }
        }
    }
}
