using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;

namespace Emporium.ViewModels.DialogWindows
{
    public class EmployeeDetailsViewModel : BaseDetailsViewModel<Employee, EmployeesService>
    {
        public EmployeeDetailsViewModel(EmployeesService employeesService) : base(employeesService)
        { }
    }
}