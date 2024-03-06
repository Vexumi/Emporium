using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;

namespace Emporium.ViewModels.DialogWindows
{
    public class PickupPointDetailsViewModel : BaseDetailsViewModel<PickupPoint, PickupPointsService>
    {
        public PickupPointDetailsViewModel(PickupPointsService pickPointsService) : base(pickPointsService)
        { }
    }
}