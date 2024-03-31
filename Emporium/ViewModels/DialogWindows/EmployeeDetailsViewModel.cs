using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using System.Threading.Tasks;

namespace Emporium.ViewModels.DialogWindows
{
    public class EmployeeDetailsViewModel : BaseDetailsViewModel<Employee, EmployeesService>
    {
        private readonly UsersService usersService;
        public EmployeeDetailsViewModel(EmployeesService employeesService, UsersService usersService) : base(employeesService)
        { 
            this.usersService = usersService;
        }

        public override async Task Delete()
        {
            var userTemp = Item.User;

            await this.service.Delete(Item);
            await this.usersService.Delete(userTemp);

            this._window.DialogResult = true;
        }
    }
}