using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emporium.ViewModels.DialogWindows
{
    public class EmployeeAddViewModel : BaseDetailsViewModel<Employee, EmployeesService>
    {
        private readonly PickupPointsService pickupPointsService;
        private readonly UsersService usersService;
        private ObservableCollection<PickupPoint> _pickupPoints;

        public EmployeeAddViewModel(EmployeesService employeesService,
            PickupPointsService pickupPointsService,
            UsersService userService) : base(employeesService)
        {
            this.pickupPointsService = pickupPointsService;
            this.usersService = userService;
        }

        public ObservableCollection<PickupPoint> PickupPoints
        {
            get
            {
                if (_pickupPoints == null)
                {
                    this._pickupPoints = new ObservableCollection<PickupPoint>(this.pickupPointsService.GetAll().ToArray());
                }
                return this._pickupPoints;
            }
        }

        public void OnPickupPointSelected(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this.Item.PickupPointId = ((PickupPoint?)(comboBox?.SelectedItem))?.Id;
        }

        public override async Task Save()
        {
            await this.usersService.Create(Item.User);

            Item.UserId = Item.User.Id ?? 0;
            Item.User = null;

            await this.service.Create(Item);

            this._window.DialogResult = true;
        }
    }
}
