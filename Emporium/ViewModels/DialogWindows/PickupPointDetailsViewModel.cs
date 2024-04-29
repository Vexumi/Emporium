using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Extensions;
using Emporium.Models;
using Emporium.Services;
using System.Threading.Tasks;

namespace Emporium.ViewModels.DialogWindows
{
    public class PickupPointDetailsViewModel : BaseDetailsViewModel<PickupPoint, PickupPointsService>
    {
        public PickupPointDetailsViewModel(PickupPointsService pickPointsService) : base(pickPointsService)
        { }

        public override async Task Delete()
        {
            if (Item.Employees.Count != 0)
            {
                MessageBoxExtensions.Error("Ошибка удаления ПВЗ", "К удаляемому ПВЗ привязаны сотрудники, сначала удалите или отвяжите сотрудников!");
                return;
            }
            await this.service.Delete(Item);
            this._window.DialogResult = true;
        }
    }
}