using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;

namespace Emporium.ViewModels.DialogWindows
{
    public class PickupPointAddViewModel : BaseDetailsViewModel<PickupPoint, PickupPointsService>
    {
        public PickupPointAddViewModel(PickupPointsService pickupPointService) : base(pickupPointService)
        { }
    }
}
